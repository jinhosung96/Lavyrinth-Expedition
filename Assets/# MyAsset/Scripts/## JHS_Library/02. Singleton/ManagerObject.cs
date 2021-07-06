using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 해당 클래스를 상속 받는 객체는 자동으로 싱글톤 오브젝트가 된다. <para></para>
    /// 참고 : 싱글톤 패턴 - https://victorydntmd.tistory.com/293?category=719467 <para></para>
    ///
    /// </summary>
     #endregion
    public abstract class ManagerObject<T> : MonoBehaviour where T : ManagerObject<T>
    {
        #region 필드

        private static T s_instance;

        #endregion

        #region 속성

        public static T Instance => s_instance = s_instance ? s_instance : FindObjectOfType<T>() ?? new GameObject(typeof(T).Name).AddComponent<T>();

        #endregion

        #region 유니티 생명주기

        protected void Awake()
        {
            var objs = FindObjectsOfType<T>();
            if (!objs.Length.Equals(1))
            {
                Destroy(gameObject);
                Debug.Log("중복 생성된 싱글톤 객체가 있어 파괴됩니다.");
                return;
            }
            else DontDestroyOnLoad(gameObject);
        }

        #endregion
    }
}
