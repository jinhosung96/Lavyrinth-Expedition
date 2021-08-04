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
    public class AuthoritySystem : JHS.SystemObject<AuthoritySystem>
    {
        #region 변수

        bool isAuthorityByMercenary = false;

        #endregion

        #region 속성

        public bool IsAuthorityByMercenary
        {
            get => isAuthorityByMercenary;
            set
            {
                isAuthorityByMercenary = value;
                ObserverSystem.Instance.PostNofication("용병 권한 갱신");
            }
        }

        #endregion
    }
}
