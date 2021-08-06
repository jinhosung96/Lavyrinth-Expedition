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
    public class IncreaseDPSByTypeText : TextFrame
    {
        #region 필드

        [SerializeField] UnitType type;

        #endregion

        #region 재정의 메소드

        protected override string WriteText()
        {
            if (type == UnitType.Hero)
            {
                BigInteger increaseDPS = HeroSystem.Instance.Hero.UpgradeInfo.increaseDPS;
                return $"{increaseDPS.GetRoughNumber()}{increaseDPS.GetUnit()}";
            }
            else
            {
                BigInteger increaseDPS = MercenarySystem.Instance.Mercenaries[(int)type].UpgradeInfo.increaseDPS;
                return $"{increaseDPS.GetRoughNumber()}{increaseDPS.GetUnit()}";
            }
        }

        #endregion
    }
}
