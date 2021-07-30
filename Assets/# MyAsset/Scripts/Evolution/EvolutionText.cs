using System.Collections;
using System.Collections.Generic;
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
    public class EvolutionText : TextFrame
    {
        #region 필드

        [SerializeField] int level;

        #endregion
        #region 재정의 메소드

        protected override string WriteText()
        {
            if (level <= EvolutionSystem.Instance.EvolutionLevel) return "각성 완료";
            else return "각성하기";
        }    

        #endregion
    }
}
