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
    public class ToggleInteractable : MonoBehaviour
    {
        #region 필드

        [SerializeField] string[] eventNames;
        [SerializeField] UnitType type;
        Button button;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            button = GetComponent<Button>();
            ToggleButton();
            for (int i = 0; i < eventNames.Length; i++)
            {
                ObserverSystem.Instance.AddListener(eventNames[i], gameObject, ToggleButton);
            }            
        }

        #endregion

        #region 내부 메소드

        void ToggleButton()
        {
            if (type == UnitType.Hero) button.interactable = HeroSystem.Instance.UpgradeInfo.canPurchase;
            else
            {
                if (AuthoritySystem.Instance.IsAuthorityByMercenary)
                {
                    button.interactable = MercenarySystem.Instance.Mercenaries[(int)type].UpgradeInfo.canPurchase;
                }
                else button.interactable = false;
            }
        }

        #endregion
    }
}
