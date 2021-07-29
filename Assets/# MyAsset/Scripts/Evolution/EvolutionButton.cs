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
    public class EvolutionButton : ButtonClick
    {
        #region 필드

        [SerializeField] int level;

        #endregion

        #region 재정의 메소드

        public override void OnClick()
        {
            if (EvolutionData.Instance.EvolutionLevel + 1 == level) EvolutionData.Instance.EvolutionLevel++;
        }

        #endregion
    }
}
