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
    public class EvolutionButton : ButtonClick
    {
        #region 필드

        [SerializeField] int level;
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
                EvolutionSystem.Instance.EvolutionLevel++;
            }
        }

        #endregion
    }
}
