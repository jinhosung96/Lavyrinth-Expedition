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

        [SerializeField] string name;
        [SerializeField] Sprite icon_noEffect;
        [SerializeField] Sprite icon_effect;

        #endregion

        #region 속성

        public string Name => name;
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
                count = value;
                Def.Slot.Icon.sprite = Def.Icon_NoEffect;
                Def.Slot.Count.text = $"{Count}/{EquipSystem.Instance.SynthesisCount}";
                if (count > 0) Def.Slot.gameObject.SetActive(true);
                else Def.Slot.gameObject.SetActive(false);
                ObserverSystem.Instance.PostNofication("장비 보유 개수 갱신");
            }
        }

        #endregion

        #region 공개 메소드

        public void InitUIElemental(int tier)
        {
            Def.Slot.Icon.sprite = Def.Icon_NoEffect;
            Def.Slot.Tier.text = $"T{tier}";
            Def.Slot.Count.text = $"{Count}/{EquipSystem.Instance.SynthesisCount}";
            if(Count <= 0) Def.Slot.gameObject.SetActive(false);
        }

        #endregion
    }
}
