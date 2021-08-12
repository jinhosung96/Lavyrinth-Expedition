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
    public class TapDamageText : TextFrame
    {
        #region 재정의 메소드

        protected override string WriteText()
        {
            BigInteger attackDamage = HeroSystem.Instance.Hero.AttackDamage;
            return $"{attackDamage.GetRoughNumber()}<color=#DAD9FF>{attackDamage.GetUnit()}</color>";
        }

        #endregion
    }
}
