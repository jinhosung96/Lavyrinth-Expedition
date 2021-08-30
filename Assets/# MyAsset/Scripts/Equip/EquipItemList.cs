using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
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

        [SerializeField] EquipSlot equipSlot;
        [SerializeField] EquipItem[] totals;
        EquipItem[] holdings;
        EquipItem currentEquip;

        #endregion

        #region 속성

        public EquipSlot EquipSlot => equipSlot;
        public EquipItem[] Totals => totals;
        public EquipItem[] Holdings { get => holdings; private set => holdings = value; }
        public EquipItem CurrentEquip
        {
            get => currentEquip; private set
            {
                if(currentEquip != null) currentEquip.Def.Slot.Icon.sprite = currentEquip.Def.Icon_NoEffect;
                currentEquip = value;
                currentEquip.Def.Slot.Icon.sprite = currentEquip.Def.Icon_Effect;
                EquipSlot.Icon.sprite = currentEquip.Def.Icon_Effect;
                EquipSlot.Name.text = currentEquip.Def.Name;
                EquipSlot.Tier.text = $"Tier {currentEquip.Def.Tier}";
                EquipSlot.AmplificationDPS.text = $"<color=#DAD9FF>+ DPS </color>{currentEquip.Def.AmplificationDPS}<color=#DAD9FF>% 증폭</color>";
            }
        }

        #endregion

        #region 공개 메소드

        public void UpdateHoldingItem()
        {
            Holdings = (from item in totals where item.Count > 0 select item).ToArray();
        }

        public void UpdateCurrentEquip()
        {
            if(Holdings.Length > 0) CurrentEquip = Holdings[Holdings.Length - 1];
        }

        #endregion
    }
}
