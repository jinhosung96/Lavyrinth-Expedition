using DG.Tweening;
using UnityEngine.UI;
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
    public class BossState : State
    {
        #region 필드

        [SerializeField] Image fadeObj;

        #endregion

        #region 재정의 메소드

        /// <summary>
        /// 유니티 생명주기 상의 Awake에서 실행
        /// </summary>
        protected override void OnAwake()
        {
            ObserverSystem.Instance.AddListener("KillBoss", gameObject, () =>
            {
                if (Machine.CurrentState != this) return;
                
                Machine.SetState(GetComponent<NormalState>());
                StageSystem.Instance.Round++;
            });
            ObserverSystem.Instance.AddListener("DeathHero", gameObject, () =>
            {
                if (Machine.CurrentState != this) return;

                fadeObj.DOFade(1, StageSystem.Instance.RoundChangeDelay * 0.5f).OnComplete(() =>
                {
                    fadeObj.DOFade(0, StageSystem.Instance.RoundChangeDelay * 0.5f);
                    PoolManager.Instance.PushObject(HeroSystem.Instance.CurrentTarget.gameObject);
                    HPBarSystem.Instance.BossAndHeroHPBarGO.SetActive(false);
                    HPBarSystem.Instance.MonsterHPBarGO.SetActive(true);
                    HPBarSystem.Instance.MonsterHPBar.ResetHPBar();
                    Machine.SetState(GetComponent<InfinityState>());
                });
            });
        }

        /// <summary>
        /// 본 상태로 진입했을 때 실행
        /// </summary>
        public override void OnEnter()
        {
            StageSystem.Instance.NextEnemy(EnemySystem.Instance.SpawnRandomBoss());
        }

        #endregion
    }
}
