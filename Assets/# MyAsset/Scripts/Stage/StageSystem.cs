using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : <para></para>
    /// 
    /// </summary>
    #endregion
    public class StageSystem : JHS.SystemObject<StageSystem>
    {
        #region 필드

        [SerializeField] float roundChangeDelay;

        #endregion

        #region 속성

        public float RoundChangeDelay => roundChangeDelay;

        #endregion

        #region 유니티 생명주기

        private void Start()
        {
            ChangeRound();
        }

        #endregion

        #region 공개 메소드

        public void ChangeRound()
        {
            StartCoroutine(Co_ChangeRound());
        }

        #endregion

        #region 내부 메소드

        IEnumerator Co_ChangeRound()
        {
            GameObject monster = EnemySystem.Instance.SpawnRandomMonster();
            GameObject tile = TileSystem.Instance.SpawnRandomTile();

            HeroSystem.Instance.HeroRoundChangeMotion.StartRoundChange();
            MercenarySystem.Instance.CurrentWarrior.GetComponent<MercenaryRoundChangeMotion>().StartRoundChange();
            MercenarySystem.Instance.CurrentArcher.GetComponent<MercenaryRoundChangeMotion>().StartRoundChange();
            MercenarySystem.Instance.CurrentMage.GetComponent<MercenaryRoundChangeMotion>().StartRoundChange();
            HeroSystem.Instance.CurrentTarget?.GetComponent<MonsterRoundEndMotion>().StartRoundChange();
            TileSystem.Instance.CurrentTile.GetComponent<TileRoundEndMotion>().StartRoundChange();
            monster.GetComponent<MonsterRoundStartMotion>().StartRoundChange();
            tile.GetComponent<TileRoundStartMotion>().StartRoundChange();

            yield return new WaitForSeconds(roundChangeDelay);

            HeroSystem.Instance.HeroRoundChangeMotion.EndRoundChange();
            MercenarySystem.Instance.CurrentWarrior.GetComponent<MercenaryRoundChangeMotion>().EndRoundChange();
            MercenarySystem.Instance.CurrentArcher.GetComponent<MercenaryRoundChangeMotion>().EndRoundChange();
            MercenarySystem.Instance.CurrentMage.GetComponent<MercenaryRoundChangeMotion>().EndRoundChange();
            HeroSystem.Instance.CurrentTarget?.GetComponent<MonsterRoundEndMotion>().EndRoundChange();
            TileSystem.Instance.CurrentTile.GetComponent<TileRoundEndMotion>().EndRoundChange();
            monster.GetComponent<MonsterRoundStartMotion>().EndRoundChange();
            tile.GetComponent<TileRoundStartMotion>().EndRoundChange();
        }

        #endregion
    }
}
