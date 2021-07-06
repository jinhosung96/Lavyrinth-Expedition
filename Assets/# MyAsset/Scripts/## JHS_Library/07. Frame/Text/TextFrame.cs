using UnityEngine;
using UnityEngine.UI;
using System;

namespace JHS
{    
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 주어진 키워드의 이벤트 발생 시 텍스트를 갱신하는 프레임 <para></para>
    /// 
    /// </summary>
     #endregion
    [RequireComponent(typeof(Text))]
    public abstract class TextFrame : MonoBehaviour
    {
        #region 필드

        Text m_textUI;

        [SerializeField, LabelName("접두사")] string m_prefix;
        [SerializeField, LabelName("접미사")] string m_suffix;
        [SerializeField, LabelName("키워드")] string m_keyword;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            m_textUI = GetComponent<Text>();
            if (!String.IsNullOrWhiteSpace(m_keyword)) ObserverSystem.Instance.AddListener(m_keyword, gameObject, RefreshUIElement, false);
        }

        void OnEnable()
        {
            RefreshUIElement();
        }

        #endregion

        #region 구현 메소드

        void RefreshUIElement()
        {
            m_textUI.text = $"{m_prefix}{WriteText()}{m_suffix}";
        }

        #endregion

        #region 추상 메소드

        protected abstract string WriteText();

        #endregion
    }
}
