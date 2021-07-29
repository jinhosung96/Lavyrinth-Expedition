using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace JHS
{
    #region EvolutionDataEditor

    #if UNITY_EDITOR
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : EvolutionData를 MenuItem을 통해 생성 및 선택 <para></para>
    /// 
    /// </summary>
    #endregion
    [CustomEditor(typeof(EvolutionData))]
    public class EvolutionDataEditor : Editor
    {
        [MenuItem("Assets/Open EvolutionData")]
        public static void OpenInspector()
        {
            Selection.activeObject = EvolutionData.Instance;
        }
    }
    #endif

    #endregion

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : <para></para>
    /// 
    /// </summary>
    #endregion
    public class EvolutionData : JHS.DataObject<EvolutionData>
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
