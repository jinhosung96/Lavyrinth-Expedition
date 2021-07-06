using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace JHS
{    
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 해당 클래스를 상속 받는 객체는 자동으로 싱글톤 스크립터블 오브젝트가 된다. <para></para>
    /// 참고 : 싱글톤 패턴 - https://victorydntmd.tistory.com/293?category=719467 <para></para>
    /// 
    /// </summary>
     #endregion
    public class DataObject<T> : ScriptableObject where T : DataObject<T>
    {
        #region 필드

#if UNITY_EDITOR
        static string s_settingFileDirectory = "Assets/Resources";
        static string s_settingFilePath = $"Assets/Resources/{typeof(T).Name}.asset";
#endif

        static T s_instance;

        #endregion

        #region 속성

        public static T Instance
        {
            get
            {
                if (s_instance) return s_instance;

                s_instance = Resources.Load<T>(typeof(T).Name);

#if UNITY_EDITOR
                if (!s_instance)
                {
                    if (!AssetDatabase.IsValidFolder(s_settingFileDirectory))
                    {
                        AssetDatabase.CreateFolder("Assets", "Resources");
                    }

                    s_instance = AssetDatabase.LoadAssetAtPath<T>(typeof(T).Name);

                    if (!s_instance)
                    {
                        s_instance = CreateInstance<T>();
                        AssetDatabase.CreateAsset(s_instance, s_settingFilePath);
                        AssetDatabase.ImportAsset(s_settingFilePath);
                    }
                }
#endif

                return s_instance;
            }
        } 

        #endregion
    }
}
