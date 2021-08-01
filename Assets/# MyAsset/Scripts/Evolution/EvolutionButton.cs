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
            ObserverSystem.Instance.AddListener("각성", gameObject, () =>
            {
                if (level <= EvolutionSystem.Instance.EvolutionLevel) button.interactable = false;
            });
        }

        #endregion

        #region 재정의 메소드

        public override void OnClick()
        {
            if (EvolutionSystem.Instance.EvolutionLevel + 1 == level)
            {
                Assert.IsFalse(evolutionConditions.Length == 0, "설정된 각성 조건이 없습니다 err01");
                Assert.IsFalse(Array.Exists(evolutionConditions, x => x == null), "설정된 각성 조건이 없습니다 err02");

                if (!Array.Exists(evolutionConditions, x => x.GetCondition() == false))
                {
                    EvolutionSystem.Instance.EvolutionLevel++;
                }                
            }
        }

        #endregion
    }
}
