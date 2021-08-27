using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    [System.Serializable]
    public class EquipItemByType
    {
        #region 필드

        [SerializeField] EquipItemList weaponList;
        [SerializeField] EquipItemList helmetList;
        [SerializeField] EquipItemList armorList;
        [SerializeField] EquipItemList glovesList;
        [SerializeField] EquipItemList shoesList;

        #endregion

        #region 속성

        public EquipItemList WeaponList => weaponList;
        public EquipItemList HelmetList => helmetList;
        public EquipItemList ArmorList => armorList;
        public EquipItemList GlovesList => glovesList;
        public EquipItemList ShoesList => shoesList;

        #endregion

        #region 인덱서

        public EquipItemList this[EquipItemType type]
        {
            get
            {
                switch (type)
                {
                    case EquipItemType.Weapon:
                        return WeaponList;
                    case EquipItemType.Helmet:
                        return HelmetList;
                    case EquipItemType.Armor:
                        return ArmorList;
                    case EquipItemType.Gloves:
                        return GlovesList;
                    case EquipItemType.Shoes:
                        return ShoesList;
                    default:
                        return null;
                }
            }
        }

        #endregion
    }
}
