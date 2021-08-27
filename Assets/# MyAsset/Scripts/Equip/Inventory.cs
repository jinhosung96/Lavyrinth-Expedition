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

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            for (int i = 0; i < EquipSystem.Instance.EquipItemList[type].Items.Length; i++)
            {
                EquipItem equipItem = EquipSystem.Instance.EquipItemList[type].Items[i];

                GameObject slotObj = PoolManager.Instance.PopObject(EquipSystem.Instance.Slot);
                EquipItemSlot slot = slotObj.GetComponent<EquipItemSlot>();
                slotObj.transform.SetParent(transform);
                equipItem.Def.Slot = slot;
                equipItem.InitUIElemental(i);
            }
        }

        #endregion
    }
}
