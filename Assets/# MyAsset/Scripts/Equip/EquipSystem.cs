using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JHS
{
    public enum EquipItemType
    {
        Weapon,
        Helmet,
        Armor,
        Gloves,
        Shoes
    }

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : <para></para>
    /// 
    /// </summary>
    #endregion
    public class EquipSystem : JHS.SystemObject<EquipSystem>
    {
        #region 필드

        [SerializeField] EquipItemByType equipItemList;
        [SerializeField] GameObject slot;
        [SerializeField] int synthesisCount;

        #endregion

        #region 속성

        public EquipItemByType EquipItemList => equipItemList;
        public GameObject Slot => slot;
        public int SynthesisCount => synthesisCount;

        #endregion

        #region 유니티 생명주기

        protected override void Awake()
        {
            base.Awake();

            for (int type = 0; type < 5; type++)
            {
                EquipItemList equipItemListByType = EquipItemList[(EquipItemType)type];
                for (int i = 0; i < equipItemListByType.Items.Length; i++)
                {
                    EquipItem equipItem = equipItemListByType.Items[i];
                    equipItem.Def.Type = (EquipItemType)type;

                    GameObject slotObj = PoolManager.Instance.PopObject(Slot);
                    EquipItemSlot slot = slotObj.GetComponent<EquipItemSlot>();
                    slotObj.transform.SetParent(equipItemListByType.Inventory);
                    equipItem.Def.Slot = slot;
                    equipItem.InitUIElemental(i);
                }
                equipItemListByType.UpdateHoldingItem();
                equipItemListByType.UpdateCurrentEquip();
            }
        }

        #endregion
    }
}
