using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public class InfinityState : State
    {
        #region 필드

        [SerializeField] Image fadeObj;
        [SerializeField] GameObject retryButton;
        [SerializeField] GameObject roundViewer;

        #endregion

        #region 재정의 메소드

        /// <summary>
        /// 유니티 생명주기 상의 Awake에서 실행
        /// </summary>
        protected override void OnAwake()
        {
            ObserverSystem.Instance.AddListener("KillMonster", gameObject, () =>
            {
                if (Machine.CurrentState == this) Machine.SetState(this);
            });
            ObserverSystem.Instance.AddListener("RetryBoss", gameObject, () =>
            {
                if (Machine.CurrentState != this) return;

                fadeObj.raycastTarget = true;
                fadeObj.DOFade(1, StageSystem.Instance.RoundChangeDelay).OnComplete(() =>
                {
                    fadeObj.DOFade(0, StageSystem.Instance.RoundChangeDelay).OnComplete(() =>
                    {
                        fadeObj.raycastTarget = false;
                    });
                    PoolManager.Instance.PushObject(HeroSystem.Instance.CurrentTarget.gameObject);
                    HPBarSystem.Instance.MonsterHPBarGO.SetActive(false);
                    HPBarSystem.Instance.BossAndHeroHPBarGO.SetActive(true);
                    HPBarSystem.Instance.BossHPBar.ResetHPBar();
                    Machine.SetState(GetComponent<BossState>());
                });
            });
        }

        /// <summary>
        /// 본 상태로 진입했을 때 실행
        /// </summary>
        public override void OnEnter()
        {
            retryButton.SetActive(true);
            roundViewer.SetActive(false);
            StageSystem.Instance.NextEnemy(EnemySystem.Instance.SpawnRandomMonster());
        }

        /// <summary>
        /// 본 상태에서 나갈 때 실행 
        /// </summary>
        public override void OnExit()
        {
            retryButton.SetActive(false);
            roundViewer.SetActive(true);
        }

        #endregion
    }
}
