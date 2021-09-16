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
    public class Notice : MonoBehaviour
    {
        #region 필드

        [SerializeField] string eventName_Notice;
        [SerializeField] string eventName_Confirm;
        [SerializeField] GameObject targetGO;

        bool isNotice;

        #endregion

        #region 속성

        public bool IsNotice
        {
            get => isNotice; set
            {
                if (targetGO && targetGO.activeInHierarchy) return;
                
                isNotice = value;
                gameObject.SetActive(isNotice);
            }
        }

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            ObserverSystem.Instance.AddListener(eventName_Notice, gameObject, () => { IsNotice = true; }, false);
            ObserverSystem.Instance.AddListener(eventName_Confirm, gameObject, () => { IsNotice = false; }, false);
            gameObject.SetActive(false);
        }

        #endregion
    }
}
