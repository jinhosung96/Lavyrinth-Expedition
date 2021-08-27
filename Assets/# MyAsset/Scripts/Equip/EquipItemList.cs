using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [System.Serializable]
    public class EquipItemList
    {
        #region 필드

        [SerializeField] EquipItem[] items;

        #endregion

        #region 속성

        public EquipItem[] Items { get => items; }
        public EquipItem[] HoldingItems { get => (from item in items where item.Count > 0 select item).ToArray(); }
        public EquipItem CurrentEquip { get => HoldingItems[HoldingItems.Length - 1]; }

        #endregion
    }
}
