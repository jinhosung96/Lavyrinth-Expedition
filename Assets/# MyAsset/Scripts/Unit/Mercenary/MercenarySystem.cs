using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace JHS
{
    [System.Serializable]
    public class Mercenary : UpgradeUnit
    {
        #region 필드

        [SerializeField] float attackSpeed;
        MercenaryRoundChangeMotion changeMotion;

        #endregion

        #region 속성

        public override BigInteger AttackDamage => DPS * (int)(AttackSpeed * 10) / 10;
        public float AttackSpeed => attackSpeed;
        public MercenaryRoundChangeMotion ChangeMotion => changeMotion ? changeMotion : changeMotion = GO.GetComponent<MercenaryRoundChangeMotion>();

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
    public class MercenarySystem : JHS.SystemObject<MercenarySystem>
    {
        #region 필드

        [SerializeField] Mercenary[] mercenaries;

        #endregion

        #region 속성

        public Mercenary[] Mercenaries => mercenaries;

        #endregion

        #region 공개 메소드

        public void SetUpgradeInfo()
        {
            for (int i = 0; i < Mercenaries.Length; i++)
            {
                Mercenaries[i].SetUpgradeInfo();
            }
        }

        #endregion
    }
}
