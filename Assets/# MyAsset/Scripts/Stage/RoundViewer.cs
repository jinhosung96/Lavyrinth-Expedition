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
    public class RoundViewer : MonoBehaviour
    {
        #region 필드

        [SerializeField] Image[] roundImgs;
        [SerializeField] Color clearColor;
        [SerializeField] Color nonClearColor;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            roundImgs = GetComponentsInChildren<Image>();
            ObserverSystem.Instance.AddListener("NextRound", gameObject, RefreshUIElement);
        }

        private void Start()
        {
            RefreshUIElement();
        }

        #endregion

        #region 내부 메소드

        void RefreshUIElement()
        {
            for (int i = 0; i < roundImgs.Length; i++)
            {
                if(i <= (StageSystem.Instance.Round - 1) % roundImgs.Length)
                {
                    roundImgs[i].color = clearColor;
                }
                else
                {
                    roundImgs[i].color = nonClearColor;
                }
            }
        }

        #endregion
    }
}
