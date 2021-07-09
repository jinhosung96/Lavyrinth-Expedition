﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 오브젝트 풀 관리 객체 <para></para>
    /// 참고 링크 : 오브젝트 풀 - https://teddy.tistory.com/21 <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. Awake()문 오버라이드시 base.Awake()를 필히 호출해야한다. <para></para>
    ///
    /// </summary>
     #endregion
    public class PoolManager : ManagerObject<PoolManager>
    {
        #region 필드

        private Dictionary<string, Stack<GameObject>> m_objPool = new Dictionary<string, Stack<GameObject>>();  //풀 오브젝트들이 들어갈 스택
        private Transform m_trPool;                                                                             //풀
        private Dictionary<string, GameObject> m_obj = new Dictionary<string, GameObject>();                    //풀에 오브젝트가 없을 경우를 대비한 비상용 오브젝트

        #endregion

        #region 유니티 생명주기

        new void Awake()
        {
            base.Awake();

            TargetObj[] m_targetObjs = PoolData.Instance.TargetObjs;

            if (m_targetObjs == null) return;

            for (int i = 0; i < m_targetObjs.Length; i++)
            {
                AddPool(m_targetObjs[i].Obj, m_targetObjs[i].PoolSize);
            }
        }

        #endregion

        #region 공개 메소드

        /// <summary>
        /// 풀 초기화
        /// </summary>
        /// <param name="_obj">초기화 대상</param>
        /// <param name="_poolSize">풀 사이즈</param>
        void AddPool(GameObject _obj, int _poolSize)
        {
            if (!m_trPool)
            {
                //풀 캐싱 <- 쉽게 생각하면 오브젝트 풀에 등록할 때 해당 오브젝트의 부모 객체라고 해석하면 됨
                m_trPool = transform;
            }

            if (!m_objPool.ContainsKey(_obj.name))
            {
                //Debug.Log($"{_obj.name} Pool 추가");

                Stack<GameObject> tempPool = new Stack<GameObject>();

                //스택 생성
                m_objPool.Add(_obj.name, tempPool);

                //오브젝트
                m_obj.Add(_obj.name, _obj);

                for (int i = 0; i < _poolSize; i++)
                {
                    //오브젝트를 생성
                    GameObject go = Instantiate(_obj) as GameObject;
                    go.name = _obj.name;
                    //풀에 푸시함
                    PushObject(go);
                }
            }
        }

        /// <summary>
        /// 대상 객체 풀에 푸쉬
        /// </summary>
        /// <param name="_obj">대상 객체</param>
        public void PushObject(GameObject _obj)
        {
            if (m_objPool.ContainsKey(_obj.name))
            {
                if (m_objPool[_obj.name].Contains(_obj)) return;

                //Debug.Log(_obj.name + "을 Pool에 반납");
                //오브젝트를 스택에 넣음
                m_objPool[_obj.name].Push(_obj);
                //오브젝트를 풀에 넣음
                _obj.transform.SetParent(m_trPool);
                //위치 초기화
                _obj.transform.position = Vector3.zero;
                // 스케일 초기화
                //_obj.transform.localScale = Vector3.one;
                //비활성화
                _obj.SetActive(false);
            }
            else
            {
                //Debug.Log($"{_obj.name}이라는 키 값의 오브젝트 풀이 없습니다");
                Debug.Log($"{_obj.name}이라는 키 값의 오브젝트 풀을 새로 생성합니다");

                AddPool(_obj, 0);
                PushObject(_obj);
            }
        }

        /// <summary>
        /// 대상 객체 풀에 일정 시간 후에 푸쉬
        /// </summary>
        /// <param name="_obj">대상 객체</param>
        /// <param name="_delay">딜레이</param>  
        public void DelayPushObject(GameObject _obj, float _delay)
        {
            StartCoroutine(Co_DelayPushObject(_obj, _delay));
        }

        /// <summary>
        /// 풀에서 대상 객체를 하나 꺼냄
        /// </summary>
        /// <param name="_objName">대상 객체 이름</param>
        /// <returns></returns>
        public GameObject PopObject(string _objName)
        {
            if (m_objPool.ContainsKey(_objName))
            {
                //Debug.Log(_objName + " Pool에서 " + _objName + "을 반환");
                if (m_objPool[_objName].Count > 0)
                {
                    //스택에서 제거
                    GameObject obj = m_objPool[_objName].Pop();
                    // 오브젝트 활성화
                    obj.SetActive(true);
                    // 스케일 초기화
                    //_obj.transform.localScale = Vector3.one;

                    return obj;
                }
                else
                {   //없을 경우 만들어서 반환
                    GameObject obj = Instantiate(m_obj[_objName]) as GameObject;
                    obj.name = m_obj[_objName].name;
                    // 오브젝트 활성화
                    obj.SetActive(true);
                    // 스케일 초기화
                    //_obj.transform.localScale = Vector3.one;

                    return obj;
                }
            }
            else
            {
                //Debug.Log($"{_objName}이라는 키 값의 오브젝트 풀이 없습니다");

                return null;
            }
        }

        /// <summary>
        /// 풀에서 대상 객체를 하나 꺼냄
        /// </summary>
        /// <param name="_obj">대상 객체</param>
        /// <returns></returns>
        public GameObject PopObject(GameObject _obj)
        {
            string objName = _obj.name;

            if (m_objPool.ContainsKey(objName))
            {
                //Debug.Log(objName + " Pool에서 " + objName + "을 반환");
                if (m_objPool[objName].Count > 0)
                {
                    //스택에서 제거
                    GameObject obj = m_objPool[objName].Pop();
                    // 오브젝트 활성화
                    obj.SetActive(true);
                    // 스케일 초기화
                    //obj.transform.localScale = Vector3.one;

                    return obj;
                }
                else
                {   //없을 경우 만들어서 반환
                    GameObject obj = Instantiate(m_obj[objName]) as GameObject;
                    obj.name = m_obj[objName].name;
                    // 오브젝트 활성화
                    obj.SetActive(true);
                    // 스케일 초기화
                    //obj.transform.localScale = Vector3.one;

                    return obj;
                }
            }
            else
            {
                //Debug.Log($"{objName}이라는 키 값의 오브젝트 풀이 없습니다");
                Debug.Log($"{objName}이라는 키 값의 오브젝트 풀을 새로 생성합니다");

                AddPool(_obj, 1);

                return PopObject(objName);
            }
        }

        /// <summary>
        /// 해당 이름을 가진 풀 비우기
        /// </summary>
        /// <param name="_objName">대상 객체 이름</param>
        public void ClearPool(string _objName)
        {
            if (m_objPool.ContainsKey(_objName))
            {
                Debug.Log($"{m_obj[_objName].name} Pool 초기화");

                for (int i = 0; i < m_objPool[_objName].Count; i++)
                {
                    GameObject obj = m_objPool[_objName].Pop();
                    Destroy(obj);
                }
            }
            else
            {
                //Debug.Log($"{_objName}이라는 키 값의 오브젝트 풀이 없습니다");
            }
        }

        /// <summary>
        /// 풀에 대상 해당 이름을 가진 키가 있는지 체크
        /// </summary>
        /// <param name="_objName">대상 객체 이름</param>
        /// <returns></returns>
        public bool ContainsKey(string _objName)
        {
            if (m_objPool.ContainsKey(_objName)) return true;
            else return false;
        }

        #endregion

        #region 내부 메소드

        IEnumerator Co_DelayPushObject(GameObject _obj, float _delay)
        {
            float timer = 0;
            while (timer < _delay)
            {
                timer += Time.deltaTime;
                yield return null;
                if (_obj.activeSelf.Equals(false)) yield break;
            }
            PushObject(_obj);
        }

        #endregion
    }
}
