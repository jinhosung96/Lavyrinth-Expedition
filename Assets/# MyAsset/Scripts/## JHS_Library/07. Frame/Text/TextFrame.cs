using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Serialization;

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

        [SerializeField, LabelName("접두사")] string prefix;
        [SerializeField, LabelName("접미사")] string suffix;
        [SerializeField] string[] keywords;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            m_textUI = GetComponent<Text>();
            for (int i = 0; i < keywords.Length; i++)
            {
                ObserverSystem.Instance.AddListener(keywords[i], gameObject, RefreshUIElement, false);
            }
        }

        void OnEnable()
        {
            RefreshUIElement();
        }

        #endregion

        #region 내부 메소드

        public void RefreshUIElement()
        {
            m_textUI.text = $"{prefix}{WriteText()}{suffix}";
        }

        #endregion

        #region 추상 메소드

        protected abstract string WriteText();

        #endregion
    }
}