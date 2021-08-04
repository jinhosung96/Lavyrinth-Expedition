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
    public class ToggleInfo : MonoBehaviour
    {
        #region 필드

        [SerializeField] GameObject upgradeinfo;
        [SerializeField] GameObject lockInfo;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            ObserverSystem.Instance.AddListener("용병 권한 갱신", gameObject, Toggle, false);
        }

        #endregion

        #region 내부 메소드

        void Toggle()
        {
            upgradeinfo.SetActive(AuthoritySystem.Instance.IsAuthorityByMercenary);
            lockInfo.SetActive(!AuthoritySystem.Instance.IsAuthorityByMercenary);
        }

        #endregion
    }
}
