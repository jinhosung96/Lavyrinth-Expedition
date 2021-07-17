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
    public class SetUpgradeSizeButton : ButtonClick
    {
        #region 필드

        [SerializeField] UpgradeSizeButtonType upgradeSizeButtonType;
        [SerializeField] int upgradeSize;
        [SerializeField] Color activeColor;
        [SerializeField] Color disableColor;

        #endregion

        #region 재정의 메소드

        public override void OnClick()
        {
            UpgradeSystem.Instance.UpgradeSize = upgradeSize;

            for (int i = 0; i < UpgradeSystem.Instance.UpgradeSizeButtons.Length; i++)
            {
                if (i != (int)upgradeSizeButtonType) UpgradeSystem.Instance.UpgradeSizeButtons[i].color = disableColor;
                else UpgradeSystem.Instance.UpgradeSizeButtons[i].color = activeColor;
            }
        }

        #endregion
    }
}
