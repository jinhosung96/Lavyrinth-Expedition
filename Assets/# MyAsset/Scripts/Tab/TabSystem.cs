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
    public class TabSystem : JHS.SystemObject<TabSystem>
    {
        #region 필드

        [SerializeField] GameObject[] bottomTabs;

        #endregion

        #region 속성

        public GameObject[] BottomTabs { get => bottomTabs; set => bottomTabs = value; }

        #endregion
    }
}
