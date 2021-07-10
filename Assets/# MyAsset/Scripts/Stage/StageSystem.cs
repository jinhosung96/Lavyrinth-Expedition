using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
        [SerializeField] string initRoundHP;
        [SerializeField] float increaseRoundHP;
        [SerializeField] string initRoundGold;
        [SerializeField] float increaseRoundGold;
        int round = 1;

        #endregion

        #region 속성

        public float RoundChangeDelay => roundChangeDelay;

        public int Round
        {
            get => round; set
            {
                round = value;
                ObserverSystem.Instance.PostNofication("NextRound");
            }
        }

        public BigInteger RoundHP => BigInteger.Parse(initRoundHP) * (int)(Mathf.Pow(increaseRoundHP, round - 1) * 100) / 100;

        public BigInteger RoundGold => BigInteger.Parse(initRoundGold) * (int)(Mathf.Pow(increaseRoundGold, round - 1) * 100) / 100;

        #endregion

        #region 공개 메소드

        public void NextEnemy(GameObject enemy)
        {
            StartCoroutine(Co_NextEnemy(enemy));
        }

        #endregion

        #region 내부 메소드

        IEnumerator Co_NextEnemy(GameObject enemy)
        {
            GameObject tile = TileSystem.Instance.SpawnRandomTile();

            HeroSystem.Instance.HeroRoundChangeMotion.StartRoundChange();
            MercenarySystem.Instance.CurrentWarrior?.GetComponent<MercenaryRoundChangeMotion>().StartRoundChange();
            MercenarySystem.Instance.CurrentArcher?.GetComponent<MercenaryRoundChangeMotion>().StartRoundChange();
            MercenarySystem.Instance.CurrentMage?.GetComponent<MercenaryRoundChangeMotion>().StartRoundChange();
            HeroSystem.Instance.CurrentTarget?.GetComponent<EnemyRoundEndMotion>().StartRoundChange();
            TileSystem.Instance.CurrentTile.GetComponent<TileRoundEndMotion>().StartRoundChange();
            enemy.GetComponent<EnemyRoundStartMotion>().StartRoundChange();
            tile.GetComponent<TileRoundStartMotion>().StartRoundChange();

            yield return new WaitForSeconds(RoundChangeDelay);

            HeroSystem.Instance.HeroRoundChangeMotion.EndRoundChange();
            MercenarySystem.Instance.CurrentWarrior?.GetComponent<MercenaryRoundChangeMotion>().EndRoundChange();
            MercenarySystem.Instance.CurrentArcher?.GetComponent<MercenaryRoundChangeMotion>().EndRoundChange();
            MercenarySystem.Instance.CurrentMage?.GetComponent<MercenaryRoundChangeMotion>().EndRoundChange();
            HeroSystem.Instance.CurrentTarget?.GetComponent<EnemyRoundEndMotion>().EndRoundChange();
            TileSystem.Instance.CurrentTile.GetComponent<TileRoundEndMotion>().EndRoundChange();
            enemy.GetComponent<EnemyRoundStartMotion>().EndRoundChange();
            tile.GetComponent<TileRoundStartMotion>().EndRoundChange();
        }

        #endregion
    }
}
