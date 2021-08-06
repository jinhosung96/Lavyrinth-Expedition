using System;
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
        [SerializeField] string initIncreaseRoundHP;
        [SerializeField] float increaseRoundHP;
        [SerializeField] string initRoundGold;
        [SerializeField] string initIncreaseRoundGold;
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

        public BigInteger RoundHP => BigInteger.Parse(initRoundHP) + BigInteger.Parse(initIncreaseRoundHP) * (BigInteger)(Math.Pow(increaseRoundHP, round - 1) * 100) / 100;

        public BigInteger RoundGold => BigInteger.Parse(initRoundGold) + BigInteger.Parse(initIncreaseRoundGold) * (BigInteger)(Math.Pow(increaseRoundGold, round - 1) * 100) / 100;

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
            for (int i = 0; i < MercenarySystem.Instance.Mercenaries.Length; i++)
            {
                MercenarySystem.Instance.Mercenaries[i].ChangeMotion.StartRoundChange();
            }                
            HeroSystem.Instance.CurrentTarget?.GetComponent<EnemyRoundEndMotion>().StartRoundChange();
            TileSystem.Instance.CurrentTile.GetComponent<TileRoundEndMotion>().StartRoundChange();
            enemy.GetComponent<EnemyRoundStartMotion>().StartRoundChange();
            tile.GetComponent<TileRoundStartMotion>().StartRoundChange();

            yield return new WaitForSeconds(RoundChangeDelay);

            HeroSystem.Instance.HeroRoundChangeMotion.EndRoundChange();
            for (int i = 0; i < MercenarySystem.Instance.Mercenaries.Length; i++)
            {
                MercenarySystem.Instance.Mercenaries[i].ChangeMotion.EndRoundChange();
            }                
            HeroSystem.Instance.CurrentTarget?.GetComponent<EnemyRoundEndMotion>().EndRoundChange();
            TileSystem.Instance.CurrentTile.GetComponent<TileRoundEndMotion>().EndRoundChange();
            enemy.GetComponent<EnemyRoundStartMotion>().EndRoundChange();
            tile.GetComponent<TileRoundStartMotion>().EndRoundChange();
        }

        #endregion
    }
}
