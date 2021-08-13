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
        GameObject condition;
        string eventName;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            switch (unitType)
            {
                case UnitType.Hero:
                    eventName = "용사 갱신";
                    break;
                case UnitType.Warrior:
                    eventName = "전사 갱신";
                    break;
                case UnitType.Archer:
                    eventName = "궁수 갱신";
                    break;
                case UnitType.Mage:
                    eventName = "법사 갱신";
                    break;
            }
            ObserverSystem.Instance.AddListener(eventName, gameObject, RefreshConditionUI, false);
        }

        private void Start()
        {
            RefreshConditionUI();
        }

        #endregion

        #region 재정의 메소드

        public override bool GetCondition()
        {
            if (unitType == UnitType.Hero) return HeroSystem.Instance.Hero.Lv >= level;
            else return MercenarySystem.Instance.Mercenaries[(int)unitType].Lv >= level;
        }

        public override void AddConditionUI(Transform evolutionConditionList)
        {
            condition = PoolManager.Instance.PopObject(EvolutionSystem.Instance.EvolutionConditions[(int)unitType + 1]);
            condition.transform.SetParent(evolutionConditionList);
            condition.transform.localScale = Vector3.one;
            condition.transform.GetChild(1).GetComponent<Text>().text = $"Lv.{level}";
        }

        #endregion

        #region 내부 메소드

        void RefreshConditionUI()
        {
            if (GetCondition())
            {
                print("실행");
                condition.transform.GetChild(1).GetComponent<Text>().color = Color.white;
            }
        }

        #endregion
    }
}
