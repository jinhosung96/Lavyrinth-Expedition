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
    public class InventoryScrollRect : NestedScrollRectFrame
    {
        #region 재정의 속성

        public override ScrollRect ParentScrollRect => EquipSystem.Instance.ScrollRect;

        #endregion
    }
}
