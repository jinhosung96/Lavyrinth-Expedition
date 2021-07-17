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
    public class TotalDamageText : TextFrame
    {
        #region 재정의 메소드

        protected override string WriteText()
        {
            BigInteger totalDPS = BigInteger.Zero;
            for (int i = 0; i < MercenarySystem.Instance.Mercenaries.Length; i++)
            {
                totalDPS += MercenarySystem.Instance.Mercenaries[i].DPS;
            }
            return $"{totalDPS.GetRoughNumber()}<color=#DAD9FF>{totalDPS.GetUnit()}</color>";
        }    

        #endregion
    }
}
