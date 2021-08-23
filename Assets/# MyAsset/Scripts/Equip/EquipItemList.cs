using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    [System.Serializable]
    public class EquipItemList
    {
        #region 필드

        [SerializeField] EquipItem[] weaponList;
        [SerializeField] EquipItem[] helmetList;
        [SerializeField] EquipItem[] armorList;
        [SerializeField] EquipItem[] glovesList;
        [SerializeField] EquipItem[] shoesList;

        #endregion

        #region 속성

        public EquipItem[] WeaponList => weaponList;
        public EquipItem[] HelmetList => helmetList;
        public EquipItem[] ArmorList => armorList;
        public EquipItem[] GlovesList => glovesList;
        public EquipItem[] ShoesList => shoesList;

        #endregion

        #region 인덱서

        public EquipItem[] this[EquipItemType type]
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
