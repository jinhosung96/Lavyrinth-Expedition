using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public class EquipSlot : MonoBehaviour
    {
        #region 필드

        [SerializeField] Image icon;
        [SerializeField] Text name;
        [SerializeField] Text tier;
        [SerializeField] Text amplificationDPS;
        [SerializeField] Transform inventoryTr;

        #endregion

        #region 속성

        public Image Icon => icon;
        public Text Name => name;
        public Text Tier => tier;
        public Text AmplificationDPS => amplificationDPS;

        #endregion

        #region 공개 메소드

        public EquipItemSlot CreateSlotObject(GameObject slotPrefab)
        {
            GameObject slotObj = PoolManager.Instance.PopObject(slotPrefab);
            EquipItemSlot slot = slotObj.GetComponent<EquipItemSlot>();
            slotObj.transform.SetParent(inventoryTr);
            return slot;
        }

        #endregion
    }
}
