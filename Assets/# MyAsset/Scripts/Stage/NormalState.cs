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
    public class NormalState : State
    {
        #region 재정의 메소드

        /// <summary>
        /// 유니티 생명주기 상의 Awake에서 실행
        /// </summary>
        protected override void OnAwake()
        {
            ObserverSystem.Instance.AddListener("KillMonster", gameObject, () =>
            {
                if (Machine.CurrentState == this)
                {
                    if (StageSystem.Instance.Round % 10 != 9) Machine.SetState(this);
                    else Machine.SetState(GetComponent<BossState>());
                }
            });
        }

        /// <summary>
        /// 본 상태로 진입했을 때 실행
        /// </summary>
        public override void OnEnter()
        {
            StageSystem.Instance.NextEnemy(EnemySystem.Instance.SpawnRandomMonster());
        }

        /// <summary>
        /// 본 상태에서 나갈 때 실행 
        /// </summary>
        public override void OnExit()
        {
            StageSystem.Instance.Round++;
        }

        #endregion
    }
}
