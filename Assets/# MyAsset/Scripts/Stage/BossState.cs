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
        #region 재정의 메소드

        /// <summary>
        /// 유니티 생명주기 상의 Awake에서 실행
        /// </summary>
        protected override void OnAwake() { }

        /// <summary>
        /// 유니티 생명주기 상의 OnEnable에서 실행
        /// </summary>
        protected override void OnActive() { }

        /// <summary>
        /// 유니티 생명주기 상의 Start에서 실행
        /// </summary>
        protected override void OnStart() { }

        /// <summary>
        /// 본 상태로 진입했을 때 실행
        /// </summary>
        public override void OnEnter() { }

        /// <summary>
        /// 유니티 생명주기 상의 FixedUpdate에서 실행 <para></para>
        /// 스테이트 머신의 현 상태가 본 상태일 때만 실행 <para></para>
        /// </summary>
        protected override void OnFixedUpdate() { }

        /// <summary>
        /// 유니티 생명주기 상의 Update에서 실행 <para></para>
        /// 스테이트 머신의 현 상태가 본 상태일 때만 실행 <para></para>
        /// </summary>
        protected override void OnUpdate() { }
        
        /// <summary>
        /// 유니티 생명주기 상의 LateUpdate에서 실행 <para></para>
        /// 스테이트 머신의 현 상태가 본 상태일 때만 실행 <para></para>
        /// </summary>
        protected override void OnLateUpdate() { }
        
        /// <summary>
        /// 본 상태에서 나갈 때 실행 
        /// </summary>
        public override void OnExit() { }

        /// <summary>
        /// 본 상태에서 나갈 때 선택적으로 실행
        /// </summary>
        public override void OnReset() { }

        /// <summary>
        /// 유니티 생명주기 상의 OnDisable에서 실행
        /// </summary>
        protected override void OnInActive() { }

        #endregion
    }
}
