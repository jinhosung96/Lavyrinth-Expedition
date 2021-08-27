using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public class CurrentEquipIcon : MonoBehaviour
    {
        #region 필드

        [SerializeField] EquipItemType type;
        Image icon;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            icon = GetComponent<Image>();
            ObserverSystem.Instance.AddListener("장비 보유 개수 갱신", gameObject, RefreshUIElemental, false);
        }

        private void Start()
        {
            RefreshUIElemental();
        }

        #endregion

        #region 내부 메소드

        void RefreshUIElemental()
        {
            icon.sprite = EquipSystem.Instance.EquipItemList[type].CurrentEquip.Def.Icon_Effect;
            EquipSystem.Instance.EquipItemList[type].CurrentEquip.Def.Slot.Icon.sprite = EquipSystem.Instance.EquipItemList[type].CurrentEquip.Def.Icon_Effect;
        }

        #endregion
    }
}
