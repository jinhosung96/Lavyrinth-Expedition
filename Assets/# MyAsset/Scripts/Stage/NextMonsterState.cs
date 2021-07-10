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
    public class NextMonsterState : State
    {
        #region 필드

        GameObject monster;
        GameObject tile;

        #endregion

        #region 재정의 메소드

        /// <summary>
        /// 본 상태로 진입했을 때 실행
        /// </summary>
        public override void OnEnter()
        {
            monster = EnemySystem.Instance.SpawnRandomMonster();
            tile = TileSystem.Instance.SpawnRandomTile();

            HeroSystem.Instance.HeroRoundChangeMotion.StartRoundChange();
            MercenarySystem.Instance.CurrentWarrior?.GetComponent<MercenaryRoundChangeMotion>().StartRoundChange();
            MercenarySystem.Instance.CurrentArcher?.GetComponent<MercenaryRoundChangeMotion>().StartRoundChange();
            MercenarySystem.Instance.CurrentMage?.GetComponent<MercenaryRoundChangeMotion>().StartRoundChange();
            HeroSystem.Instance.CurrentTarget?.GetComponent<MonsterRoundEndMotion>().StartRoundChange();
            TileSystem.Instance.CurrentTile.GetComponent<TileRoundEndMotion>().StartRoundChange();
            monster.GetComponent<MonsterRoundStartMotion>().StartRoundChange();
            tile.GetComponent<TileRoundStartMotion>().StartRoundChange();

            StartCoroutine(Co_NextMonster());
        }
        
        /// <summary>
        /// 본 상태에서 나갈 때 실행 
        /// </summary>
        public override void OnExit()
        {
            HeroSystem.Instance.HeroRoundChangeMotion.EndRoundChange();
            MercenarySystem.Instance.CurrentWarrior?.GetComponent<MercenaryRoundChangeMotion>().EndRoundChange();
            MercenarySystem.Instance.CurrentArcher?.GetComponent<MercenaryRoundChangeMotion>().EndRoundChange();
            MercenarySystem.Instance.CurrentMage?.GetComponent<MercenaryRoundChangeMotion>().EndRoundChange();
            HeroSystem.Instance.CurrentTarget?.GetComponent<MonsterRoundEndMotion>().EndRoundChange();
            TileSystem.Instance.CurrentTile.GetComponent<TileRoundEndMotion>().EndRoundChange();
            monster.GetComponent<MonsterRoundStartMotion>().EndRoundChange();
            tile.GetComponent<TileRoundStartMotion>().EndRoundChange();
        }

        #endregion

        #region 내부 메소드

        IEnumerator Co_NextMonster()
        {
            yield return new WaitForSeconds(StageSystem.Instance.RoundChangeDelay);
            if (Machine.PrevState) Machine.SetPrevState();
            else
            {
                if(StageSystem.Instance.Round % 10 != 0) Machine.SetState(GetComponent<NormalState>());
                else Machine.SetState(GetComponent<InfinityState>());
            }
        }

        #endregion
    }
}
