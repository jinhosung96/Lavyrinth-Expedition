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
    public class BottomTabButton : ButtonClick
    {
        #region 필드

        [SerializeField] int targetIndex;

        #endregion

        #region 재정의 메소드

        public override void OnClick()
        {
            for (int i = 0; i < TabSystem.Instance.BottomTabs.Length; i++)
            {
                if(targetIndex != i)
                {
                    TabSystem.Instance.BottomTabs[i].SetActive(false);
                }
                else
                {
                    TabSystem.Instance.BottomTabs[i].SetActive(true);
                }
            }
        }

        #endregion
    }
}
