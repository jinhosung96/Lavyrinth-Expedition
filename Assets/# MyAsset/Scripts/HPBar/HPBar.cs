using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
    public class HPBar : MonoBehaviour
    {
        #region 필드

        [SerializeField] Slider hpBar;

        #endregion

        #region 공개 메소드

        public void ResetHPBar()
        {
            hpBar.fillRect.gameObject.SetActive(true);
            hpBar.value = 1;
        }

        public void RefreshHPBar(BigInteger currentHP, BigInteger maxHP)
        {
            if (currentHP <= 0)
            {
                hpBar.fillRect.gameObject.SetActive(false);
                return;
            }

            int currentHPLength = currentHP.ToString().Length;
            int maxHPLength = maxHP.ToString().Length;
            if (maxHPLength > 4)
            {
                int offset = maxHPLength - currentHPLength;

                if (offset < 4)
                {
                    hpBar.value = float.Parse(currentHP.ToString().Substring(0, 4 - offset)) / float.Parse(maxHP.ToString().Substring(0, 4));
                }
                else hpBar.value = 0;

            }
            else
            {
                hpBar.value = float.Parse(currentHP.ToString()) / float.Parse(maxHP.ToString());
            }
        }

        #endregion
    }
}
