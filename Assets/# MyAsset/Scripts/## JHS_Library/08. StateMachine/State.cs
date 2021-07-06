using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 스테이트 머신에 의해 제어되는 스테이트에 대한 부모 클래스, 스테이트 머신의 현재 상태가 본 상태일 경우에만 작동한다. <para></para>
    /// 참고 : 스테이트 패턴 - https://victorydntmd.tistory.com/294 <para></para>
    ///
    /// </summary>
     #endregion
    [RequireComponent(typeof(StateMachine))]
    public class State : MonoBehaviour
    {
        #region 필드

        private StateMachine m_machine;

        #endregion

        #region 속성

        protected StateMachine Machine { get => m_machine; private set => m_machine = value; }

        #endregion

        #region 유니티 생명주기

        protected void Awake()
        {
            Machine = GetComponent<StateMachine>();
            OnAwake();
        }

        protected void OnEnable()
        {
            OnActive();
        }

        protected void Start()
        {
            OnStart();
        }

        protected void FixedUpdate()
        {
            if (!Machine.CurrentState.Equals(this)) return;
            OnFixedUpdate();
        }

        // Update is called once per frame
        protected void Update()
        {
            if (!Machine.CurrentState.Equals(this)) return;
            OnUpdate();
        }

        protected void LateUpdate()
        {
            if (!Machine.CurrentState.Equals(this)) return;
            OnLateUpdate();
        }

        protected void OnDisable()
        {
            OnInActive();
        }

        #endregion

        #region 추상 메소드

        /// <summary>
        /// 유니티 생명주기 상의 Awake에서 실행
        /// </summary>
        protected virtual void OnAwake() { }

        /// <summary>
        /// 유니티 생명주기 상의 OnEnable에서 실행
        /// </summary>
        protected virtual void OnActive() { }

        /// <summary>
        /// 유니티 생명주기 상의 Start에서 실행
        /// </summary>
        protected virtual void OnStart() { }

        /// <summary>
        /// 본 상태로 진입했을 때 실행
        /// </summary>
        public virtual void OnEnter() { } // 해당 상태로 진입했을 때

        /// <summary>
        /// 유니티 생명주기 상의 FixedUpdate에서 실행 <para></para>
        /// 스테이트 머신의 현 상태가 본 상태일 때만 실행 <para></para>
        /// </summary>
        protected virtual void OnFixedUpdate() { }

        /// <summary>
        /// 유니티 생명주기 상의 Update에서 실행 <para></para>
        /// 스테이트 머신의 현 상태가 본 상태일 때만 실행 <para></para>
        /// </summary>
        protected virtual void OnUpdate() { }
        
        /// <summary>
        /// 유니티 생명주기 상의 LateUpdate에서 실행 <para></para>
        /// 스테이트 머신의 현 상태가 본 상태일 때만 실행 <para></para>
        /// </summary>
        protected virtual void OnLateUpdate() { }
        
        /// <summary>
        /// 본 상태에서 나갈 때 실행 
        /// </summary>
        public virtual void OnExit() { }

        /// <summary>
        /// 본 상태에서 나갈 때 선택적으로 실행
        /// </summary>

        public virtual void OnReset() { }

        /// <summary>
        /// 유니티 생명주기 상의 OnDisable에서 실행
        /// </summary>
        protected virtual void OnInActive() { }

        #endregion
    }
}
