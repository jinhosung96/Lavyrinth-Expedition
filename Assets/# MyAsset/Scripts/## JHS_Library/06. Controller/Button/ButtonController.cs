using UnityEngine;
using UnityEngine.UI;

namespace JHS
{

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 본 인터페이스를 상속받는 객체는 ButtonController의 제어를 받는다. <para></para>
    ///
    /// </summary>
    #endregion
    [RequireComponent(typeof(ButtonController))]
    public abstract class ButtonClick : MonoBehaviour
    {
        public abstract void OnClick();
    }
    
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 본 클래스를 상속받은 컴포넌트는 OnClick() 메소드를 오버라이드해야하며 버튼 클릭 시 트리거에 OnClick() 메소드를 자동으로 추가한다 <para></para>
    ///
    /// ----- 주의 사항 ----- <para></para>
    /// 1. 동일 게임오브젝트에 본 클래스를 상속받은 컴포넌트가 여러개일 시 위에서부터 순서대로 트리거에 추가된다. <para></para>
    /// 2. 본 클래스를 상속할 경우 Awake 사용 시 base.Awake()를 호출해줘야 한다.
    ///
    /// </summary>
    #endregion
    [RequireComponent(typeof(Button))]
    public class ButtonController : MonoBehaviour
    {
        #region 필드
        
        Button m_button;
        ButtonClick[] m_buttonClicks;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            SetButtonClickTrigger();
        }

        #endregion

        #region 내부 메소드

        private void SetButtonClickTrigger()
        {
            m_button = GetComponent<Button>();
            m_buttonClicks = GetComponents<ButtonClick>();
            m_button.onClick.AddListener(() =>
            {
                for (int i = 0; i < m_buttonClicks.Length; i++)
                {
                    m_buttonClicks[i]?.OnClick();
                }
            });
        }

        #endregion
    }
}
