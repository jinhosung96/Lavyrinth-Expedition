using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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

        [SerializeField] ScrollRect scrollRect;
        [SerializeField] EquipItemByType equipItemList;
        [SerializeField] GameObject slotPrefab;
        [SerializeField] int synthesisCount;

        #endregion

        #region 속성

        public ScrollRect ScrollRect => scrollRect;
        public EquipItemByType EquipItemList => equipItemList;
        public int SynthesisCount => synthesisCount;
        public int Amplification
        {
            get
            {
                int amplification = 0;
                for (int type = 0; type < 5; type++)
                {
                    EquipItemList equipItemList = EquipItemList[(EquipItemType)type];
                    if(equipItemList.CurrentEquip != null) amplification += equipItemList.CurrentEquip.Def.AmplificationDPS;
                }
                return amplification;
            }
        }

        #endregion

        #region 유니티 생명주기

        protected override void Awake()
        {
            base.Awake();
            InitEquipItemLists();
        }

        private void InitEquipItemLists()
        {
            for (int type = 0; type < 5; type++)
            {
                EquipItemList equipItemList = EquipItemList[(EquipItemType)type];
                for (int i = 0; i < equipItemList.Totals.Length; i++)
                {
                    EquipItemSlot slot = equipItemList.EquipSlot.CreateSlotObject(slotPrefab);

                    EquipItem equipItem = equipItemList.Totals[i];
                    equipItem.InitDef((EquipItemType)type, i);
                    equipItem.InitSlotUI(slot);
                }
                equipItemList.UpdateHoldingItem();
                equipItemList.UpdateCurrentEquip();
            }
        }

        #endregion
    }
}
