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
    /// 개요 : 골드 재화를 텍스트로 표기 <para></para>
    /// 
    /// </summary>
    #endregion
    public class GoldText : TextFrame
    {
        #region 재정의 메소드

        protected override string WriteText()
        {
            return $"{CurrencyData.Instance.GoldRoughNumber}<color=#FFF29E>{CurrencyData.Instance.GoldUnit}</color>";
        }

        #endregion
    }
}
