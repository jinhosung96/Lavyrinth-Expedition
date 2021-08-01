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
    public abstract class EvolutionCondition : MonoBehaviour
    {
        #region 추상 메소드

        public abstract bool GetCondition();

        #endregion
    }
}
