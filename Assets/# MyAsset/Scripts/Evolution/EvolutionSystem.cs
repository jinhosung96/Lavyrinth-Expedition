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
    public class EvolutionSystem : JHS.SystemObject<EvolutionSystem>
    {
        #region 필드

        [SerializeField] int evolutionLevel;

        #endregion

        #region 속성

        public int EvolutionLevel
        {
            get => evolutionLevel; set
            {
                evolutionLevel = value;
                ObserverSystem.Instance.PostNofication("각성");
            }
        }

        #endregion
    }
}
