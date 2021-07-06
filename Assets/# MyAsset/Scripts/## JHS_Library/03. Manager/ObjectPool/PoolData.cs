using System;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace JHS
{
    #region PoolDataEditor

    #if UNITY_EDITOR
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : PoolData을 생성하기 위한 에디터 클래스이다. <para></para>
    ///
    /// </summary>
    #endregion
    [CustomEditor(typeof(PoolData))]
    public class PoolDataEditor : Editor
    {
        [MenuItem("Assets/Open PoolData")]
        public static void OpenInspector()
        {
            Selection.activeObject = PoolData.Instance;
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

    #region TargetObj

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 풀을 초기화에 사용될 객체에 대한 정보를 가지고 있는 스크립터블 오브젝트 <para></para>
    /// 
    /// </summary>
    #endregion
    [Serializable]
    public class TargetObj
    {
        [SerializeField, LabelName("대상 오브젝트")] private GameObject m_obj;
        [SerializeField, LabelName("풀 사이즈")] private int m_poolSize;

        public GameObject Obj { get => m_obj; set => m_obj = value; }
        public int PoolSize { get => m_poolSize; set => m_poolSize = value; }
    }

    #endregion

    #region 머리말 주석
    /// <summary>
    ///
    /// 최종 수정 날짜 : 2020-10-03 <para></para>
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 풀을 초기화에 사용될 객체에 대한 정보를 가지고 있는 스크립터블 오브젝트 <para></para>
    /// 
    /// </summary>
    #endregion
    public class PoolData : DataObject<PoolData>
    {
        #region 필드

        [SerializeField, ArrayElementLabelName("m_obj")] private TargetObj[] targetObjs;

        #endregion

        #region 속성

        public TargetObj[] TargetObjs { get => targetObjs; }

        #endregion
    } 
}
