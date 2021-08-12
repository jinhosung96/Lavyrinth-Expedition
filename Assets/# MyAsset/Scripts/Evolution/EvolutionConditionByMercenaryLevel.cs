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
    public class EvolutionConditionByMercenaryLevel : EvolutionCondition
    {
        #region 필드

        [SerializeField] UnitType unitType;
        [SerializeField] int level;

        #endregion

        #region 재정의 메소드

        public override bool GetCondition()
        {
            if (unitType == UnitType.Hero) return HeroSystem.Instance.Hero.Lv >= level;
            else return MercenarySystem.Instance.Mercenaries[(int)unitType].Lv >= level;
        }

        public override void AddConditionUI(Transform evolutionConditionList)
        {
            GameObject condition = PoolManager.Instance.PopObject(EvolutionSystem.Instance.EvolutionConditions[(int)unitType + 1]);
            condition.transform.SetParent(evolutionConditionList);
            condition.transform.localScale = Vector3.one;
            condition.transform.GetChild(1).GetComponent<Text>().text = $"Lv.{level}";
        }

        #endregion
    }
}
