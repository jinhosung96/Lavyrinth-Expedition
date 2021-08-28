using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
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
    [System.Serializable]
    public class EquipItemList
    {
        #region 필드

        [SerializeField] Image icon;
        [SerializeField] Transform inventory;
        [SerializeField] EquipItem[] items;
        EquipItem[] holdingItems;
        EquipItem currentEquip;

        #endregion

        #region 속성

        public Image Icon => icon;
        public Transform Inventory => inventory;
        public EquipItem[] Items => items;
        public EquipItem[] HoldingItems { get => holdingItems; private set => holdingItems = value; }
        public EquipItem CurrentEquip
        {
            get => HoldingItems[HoldingItems.Length - 1]; private set
            {
                if(currentEquip != null) currentEquip.Def.Slot.Icon.sprite = currentEquip.Def.Icon_NoEffect;
                currentEquip = value;
                Assert.IsNotNull(currentEquip, "이후에 장착할 장비가 없네??");
                Assert.IsNotNull(currentEquip.Def.Slot, "이후에 장착할 장비에 대한 슬롯이 없네??");
                currentEquip.Def.Slot.Icon.sprite = currentEquip.Def.Icon_Effect;
                Icon.sprite = currentEquip.Def.Icon_Effect;
            }
        }

        #endregion

        #region 공개 메소드

        public void UpdateHoldingItem()
        {
            HoldingItems = (from item in items where item.Count > 0 select item).ToArray();
        }

        public void UpdateCurrentEquip()
        {
            if(HoldingItems.Length > 0) CurrentEquip = HoldingItems[HoldingItems.Length - 1];
        }

        #endregion
    }
}
