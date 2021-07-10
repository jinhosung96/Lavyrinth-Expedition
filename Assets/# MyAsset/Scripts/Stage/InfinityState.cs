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
    public class InfinityState : State
    {
        #region 재정의 메소드

        /// <summary>
        /// 유니티 생명주기 상의 Awake에서 실행
        /// </summary>
        protected override void OnAwake()
        {
            ObserverSystem.Instance.AddListener("KillMonster", gameObject, () =>
            {
                if (Machine.CurrentState == this) NextMonster();
            });
            ObserverSystem.Instance.AddListener("RetryBoss", gameObject, () =>
            {
                if (Machine.CurrentState == this) RetryBoss();
            });
        }

        /// <summary>
        /// 본 상태로 진입했을 때 실행
        /// </summary>
        public override void OnEnter() { }

        /// <summary>
        /// 본 상태에서 나갈 때 실행 
        /// </summary>
        public override void OnExit() { }

        #endregion

        #region 내부 메소드

        void NextMonster()
        {
            Machine.SetState(GetComponent<NextMonsterState>());
        }

        void RetryBoss()
        {
            Machine.SetState(GetComponent<BossState>());
        }

        #endregion
    }
}
