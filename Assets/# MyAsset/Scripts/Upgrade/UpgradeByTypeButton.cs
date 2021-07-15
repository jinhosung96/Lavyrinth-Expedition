using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public class UpgradeByTypeButton : ButtonClick
    {
        #region 필드

        [SerializeField] UnitType type;

        #endregion

        #region 재정의 메소드

        public override void OnClick()
        {
            if (type == UnitType.Hero)
            {
                if (!HeroSystem.Instance.UpgradeInfo.canPurchase) return;
                HeroSystem.Instance.Lv += HeroSystem.Instance.UpgradeInfo.increaseLv;
                CurrencyData.Instance.Gold -= HeroSystem.Instance.UpgradeInfo.cost;
            }
            else
            {
                if (!MercenarySystem.Instance.Mercenaries[(int)type].UpgradeInfo.canPurchase) return;
                MercenarySystem.Instance.Mercenaries[(int)type].Lv += MercenarySystem.Instance.Mercenaries[(int)type].UpgradeInfo.increaseLv;
                CurrencyData.Instance.Gold -= MercenarySystem.Instance.Mercenaries[(int)type].UpgradeInfo.cost;
            }
        }

        #endregion
    }
}
