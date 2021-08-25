using System.Collections;
using System.Collections.Generic;
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

        [SerializeField] private EquipItemList equipItemList;
        [SerializeField] GameObject slot;
        [SerializeField] int synthesisCount;

        #endregion

        #region 속성

        public EquipItemList EquipItemList => equipItemList;
        public GameObject Slot => slot;
        public int SynthesisCount => synthesisCount;

        #endregion
    }
}
