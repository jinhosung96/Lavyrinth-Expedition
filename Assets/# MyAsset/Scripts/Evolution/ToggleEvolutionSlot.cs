using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public class ToggleEvolutionSlot: MonoBehaviour
    {
        #region 필드

        [SerializeField] int level;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            ObserverSystem.Instance.AddListener("각성", gameObject, Toggle, false);
            if (level > 4) gameObject.SetActive(false);
        }

        #endregion

        #region 내부 메소드

        void Toggle()
        {
            if(EvolutionSystem.Instance.EvolutionLevel + 1 >= level) gameObject.SetActive(true);
        }

        #endregion
    }
}
