using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JHS
{
    [System.Serializable]
    public class EquipItemDef
    {
        #region 필드

        EquipItemType type;
        int tier;
        [SerializeField] string name;
        [SerializeField] int amplicationDPS;
        [SerializeField] Sprite icon_noEffect;
        [SerializeField] Sprite icon_effect;

        #endregion

        #region 속성

        public EquipItemType Type { get => type; set => type = value; }
        public int Tier { get => tier; set => tier = value; }
        public string Name => name;
        public int AmplicationDPS => amplicationDPS;
        public Sprite Icon_NoEffect => icon_noEffect;
        public Sprite Icon_Effect => icon_effect;
        public EquipItemSlot Slot { get; set; }

        #endregion
    }

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : <para></para>
    /// 
    /// </summary>
    #endregion
    [System.Serializable]
    public class EquipItem
    {
        #region 필드

        [SerializeField] EquipItemDef def;
        [SerializeField] private int count;

        #endregion

        #region 속성

        /// <summary>
        /// 해당 아이템의 정의 반환
        /// </summary>
        public EquipItemDef Def => def;
        public int Count
        {
            get => count;
            set {
                if (count <= 0 && value > 0)
                {
                    Def.Slot.gameObject.SetActive(true);
                    EquipSystem.Instance.EquipItemList[Def.Type].UpdateHoldingItem();
                    EquipSystem.Instance.EquipItemList[Def.Type].UpdateCurrentEquip();
                }
                else if (count > 0 && value <= 0)
                {
                    Def.Slot.gameObject.SetActive(false);
                    EquipSystem.Instance.EquipItemList[Def.Type].UpdateHoldingItem();
                    EquipSystem.Instance.EquipItemList[Def.Type].UpdateCurrentEquip();
                }

                count = value;
                Def.Slot.Count.text = $"{count}/{EquipSystem.Instance.SynthesisCount}";
            }
        }

        #endregion

        #region 공개 메소드

        public void InitDef(EquipItemType type, int tier)
        {
            Def.Type = type;
            Def.Tier = tier;
        }

        public void InitSlotUI(EquipItemSlot slot)
        {
            Def.Slot = slot;
            Def.Slot.Icon.sprite = Def.Icon_NoEffect;
            Def.Slot.Tier.text = $"T{Def.Tier}";
            Def.Slot.Count.text = $"{Count}/{EquipSystem.Instance.SynthesisCount}";
            if(Count <= 0) Def.Slot.gameObject.SetActive(false);
        }

        #endregion
    }
}
