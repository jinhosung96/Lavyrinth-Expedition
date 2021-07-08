using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace JHS
{
    #region CurrencyDataEditor

#if UNITY_EDITOR
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : CurrencyData를 MenuItem을 통해 생성 및 선택 <para></para>
    /// 
    /// </summary>
    #endregion
    [CustomEditor(typeof(CurrencyData))]
    public class CurrencyDataEditor : Editor
    {
        [MenuItem("Assets/Open CurrencyData")]
        public static void OpenInspector()
        {
            Selection.activeObject = CurrencyData.Instance;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
                AssetDatabase.SaveAssets();
            }
        }
    }
#endif

    #endregion

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 인게임 재화를 관리 <para></para>
    /// 
    /// </summary>
    #endregion
    public class CurrencyData : JHS.DataObject<CurrencyData>
    {
        #region 필드

        private BigInteger gold;
        private int diamond;

        #endregion

        #region 속성

        public BigInteger Gold { get; set; }
        public int Diamond { get; set; }
        public string GoldRoughNumber { get { return gold.GetRoughNumber(); } }
        public string GoldUnit { get { return gold.GetUnit(); } }

        #endregion
    }
}
