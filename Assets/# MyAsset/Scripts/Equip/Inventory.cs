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
    public class Inventory : MonoBehaviour
    {
        #region 필드

        [SerializeField] EquipItemType type;
        List<EquipItemSlot> equipItemSlots;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            ObserverSystem.Instance.AddListener("장비 보유 개수 갱신", gameObject, RefreshUIElement, false);

            equipItemSlots = new List<EquipItemSlot>();
            for (int i = 0; i < EquipSystem.Instance.EquipItemList[type].Length; i++)
            {
                EquipItem equipItem = EquipSystem.Instance.EquipItemList[type][i];

                GameObject slotObj = PoolManager.Instance.PopObject(EquipSystem.Instance.Slot);
                EquipItemSlot slot = slotObj.GetComponent<EquipItemSlot>();
                slot.Icon.sprite = equipItem.Def.Icon_NoEffect;
                slot.Tier.text = $"T{i}";
                slot.Count.text = $"{equipItem.Count.ToString()}/{EquipSystem.Instance.SynthesisCount}";
                slotObj.transform.SetParent(transform);
                if (equipItem.Count == 0) slotObj.SetActive(false);
                equipItemSlots.Add(slot);
            }
        }

        #endregion

        #region 공개 메소드



        #endregion

        #region 내부 메소드

        void RefreshUIElement()
        {
            for (int i = 0; i < EquipSystem.Instance.EquipItemList[type].Length; i++)
            {
                EquipItem equipItem = EquipSystem.Instance.EquipItemList[type][i];
                equipItemSlots[i].Count.text = equipItem.Count.ToString();
                if (equipItem.Count > 0) equipItemSlots[i].gameObject.SetActive(true);
                else equipItemSlots[i].gameObject.SetActive(false);
            }
        }

        #endregion
    }
}
