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
        [SerializeField] int amplificationDPS;
        [SerializeField] Sprite icon;

        #endregion

        #region 속성

        public EquipItemType Type { get => type; set => type = value; }
        public int Tier { get => tier; set => tier = value; }
        public string Name => name;
        public int AmplificationDPS => amplificationDPS;
        public Sprite Icon => icon;
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
                    count = value;
                    Def.Slot.gameObject.SetActive(true);
                    EquipSystem.Instance.EquipItemList[Def.Type].UpdateHoldingItem();
                    EquipSystem.Instance.EquipItemList[Def.Type].UpdateCurrentEquip();
                }
                else if (count > 0 && value <= 0)
                {
                    count = value;
                    Def.Slot.gameObject.SetActive(false);
                    EquipSystem.Instance.EquipItemList[Def.Type].UpdateHoldingItem();
                    EquipSystem.Instance.EquipItemList[Def.Type].UpdateCurrentEquip();
                }
                else
                {
                    count = value;
                }

                if (EquipSystem.Instance.EquipItemList[Def.Type].Totals.Length - 1 != Def.Tier)
                {
                    Def.Slot.Count.text = $"{count}/{EquipSystem.Instance.SynthesisCount}";
                }
                else Def.Slot.Count.text = $"{count}";
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
            Def.Slot.Icon.sprite = Def.Icon;
            Def.Slot.Tier.text = $"T{Def.Tier}";
            Def.Slot.Count.text = $"{Count}/{EquipSystem.Instance.SynthesisCount}";
            Def.Slot.Button.Item = this;
            if (Count <= 0) Def.Slot.gameObject.SetActive(false);
        }

        public void Synthesis()
        {
            if (EquipSystem.Instance.EquipItemList[Def.Type].Totals.Length - 1 == Def.Tier) return;

            while (EquipSystem.Instance.EquipItemList[Def.Type].Totals[Def.Tier].Count >= EquipSystem.Instance.SynthesisCount)
            {
                EquipSystem.Instance.EquipItemList[Def.Type].Totals[Def.Tier].Count -= EquipSystem.Instance.SynthesisCount;
                EquipSystem.Instance.EquipItemList[Def.Type].Totals[Def.Tier + 1].Count++;
            }
        }

        #endregion
    }
}
