using System;
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
    /// 개요 : 주어진 키워드의 이벤트 발생 시 슬라이더를 갱신 <para></para>
    /// 
    /// </summary>
    #endregion
    public abstract class SliderFrame : MonoBehaviour
    {
        #region 필드

        Slider m_sliderUI;
        GameObject m_fillArea;

        [SerializeField, LabelName("키워드")] string m_keyword;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            m_sliderUI = GetComponent<Slider>();
            m_fillArea = transform.GetChild(1).gameObject;
            if (!String.IsNullOrWhiteSpace(m_keyword)) ObserverSystem.Instance.AddListener(m_keyword, gameObject, RefreshUIElement, false);
        }

        void OnEnable()
        {
            RefreshUIElement();
        }

        #endregion

        #region 내부 메소드

        void RefreshUIElement()
        {
            m_sliderUI.value = InputValue();
            if (m_sliderUI.value <= 0) m_fillArea.SetActive(false);
            else m_fillArea.SetActive(true);
        }

        #endregion

        #region 추상 메소드

        protected abstract float InputValue();

        #endregion
    }
}
