using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
    public class DPSByTypeText : TextFrame
    {
        #region 필드

        [SerializeField] UnitType type;

        #endregion

        #region 재정의 메소드

        protected override string WriteText()
        {
            if (type == UnitType.Hero)
            {
                BigInteger dps = HeroSystem.Instance.Hero.DPS;
                return $"{dps.GetRoughNumber()}<color=#DAD9FF>{dps.GetUnit()}</color>";
            }
            else
            {
                BigInteger dps = MercenarySystem.Instance.Mercenaries[(int)type].DPS;
                return $"{dps.GetRoughNumber()}<color=#DAD9FF>{dps.GetUnit()}</color>";
            }
        }

        #endregion
    }
}
