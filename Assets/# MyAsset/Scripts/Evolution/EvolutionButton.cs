using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
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
    public class EvolutionButton : ButtonClick
    {
        #region 필드

        [SerializeField] int level;
        [SerializeField] EvolutionCondition[] evolutionConditions;
        Button button;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            button = GetComponent<Button>();
            Toggle();
            ObserverSystem.Instance.AddListener("각성 레벨 갱신", gameObject, Toggle, false);
            ObserverSystem.Instance.AddListener("용사 갱신", gameObject, Toggle, false);
            ObserverSystem.Instance.AddListener("용병 갱신", gameObject, Toggle, false);
        }

        #endregion

        #region 내부 메소드

        private void Toggle()
        {            
            bool isSetting = !(evolutionConditions.Length == 0) 
                && !Array.Exists(evolutionConditions, x => x == null);
            
            if (isSetting)
            {                
                bool isEvolution = EvolutionSystem.Instance.EvolutionLevel + 1 == level 
                    && !Array.Exists(evolutionConditions, x => x.GetCondition() == false);                
                button.interactable = isEvolution;
            }            
        }

        #endregion

        #region 재정의 메소드

        public override void OnClick()
        {
            EvolutionSystem.Instance.EvolutionLevel++;
        }

        #endregion
    }
}
