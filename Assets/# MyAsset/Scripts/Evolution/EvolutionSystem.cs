using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    [System.Serializable]
    public class EvolutionInfo
    {
        #region 필드

        [SerializeField] int amplification;

        #endregion

        #region 속성

        public int Amplification => amplification;

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
    public class EvolutionSystem : JHS.SystemObject<EvolutionSystem>
    {
        #region 필드

        [SerializeField] int evolutionLevel;
        [SerializeField] EvolutionInfo[] evolutionInfos;
        [SerializeField] GameObject[] evolutionConditions;

        #endregion

        #region 속성

        public int EvolutionLevel
        {
            get => evolutionLevel; set
            {
                evolutionLevel = value;
                switch (evolutionLevel)
                {
                    case 1:
                        AuthoritySystem.Instance.IsAuthorityByMercenary = true;
                        break;
                }
                ObserverSystem.Instance.PostNofication("각성 레벨 갱신");
            }
        }

        public int Amplification
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < evolutionLevel; i++) sum += EvolutionInfos[i].Amplification;
                return sum;
            }
        }

        public EvolutionInfo[] EvolutionInfos => evolutionInfos;

        public GameObject[] EvolutionConditions => evolutionConditions;

        #endregion
    }
}
