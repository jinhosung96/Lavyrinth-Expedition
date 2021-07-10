using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 각 스테이트를 관리하는 스테이트 머신 <para></para>
    /// 참고 : 스테이트 패턴 - https://victorydntmd.tistory.com/294 <para></para>
    ///
    /// </summary>
     #endregion
    public class StateMachine : MonoBehaviour
    {
        #region 필드

        [SerializeField, LabelName("초기 상태")] State m_initState;
        State m_currentState;
        State m_prevState;

        #endregion

        #region 속성

        public State CurrentState { get => m_currentState; private set => m_currentState = value; }
        public State PrevState { get => m_prevState; private set => m_prevState = value; }

        #endregion

        #region 유니티 생명주기

        private void Start()
        {
            SetState(m_initState);
        }

        #endregion

        #region 공개 메소드
        
        /// <summary>
        /// 현재 상태를 _nextState로 전환. _isReset이 true일 시 상태를 바꾸기 전에 OnReset() 함수 호출 후 상태 전환
        /// </summary>
        /// <param name="_nextState"> 다음 상태 </param>
        /// <param name="_isReset"> 리셋 여부 </param>
        public void SetState(State _nextState, bool _isReset = true)
        {
            PrevState = CurrentState; // 현재 상태를 이전 상태로
            PrevState?.OnExit(); // 이전 상태 종료
            if (_isReset) PrevState?.OnReset(); // 이전 상태 리셋
            Debug.Log($"{PrevState?.GetType().Name} State 종료");
            CurrentState = _nextState; // 현재 상태를 다음 상태로
            Debug.Log($"{_nextState.GetType().Name} State 시작");
            CurrentState?.OnEnter(); // 현재 상태 시작
        }

        /// <summary>
        /// 현재 상태를 이전 상태로 전환
        /// </summary>
        public void SetPrevState()
        {
            State temp = PrevState;
            PrevState = CurrentState;
            CurrentState?.OnExit();
            CurrentState = temp;
            CurrentState?.OnEnter();
        }

        #endregion
    }
}
