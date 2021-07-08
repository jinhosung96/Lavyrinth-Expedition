using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 탭을 통해 영웅으로 하여금 공격하게 한다<para></para>
    /// 
    /// </summary>
    #endregion
    public class TapButton : ButtonClick
    {
        #region 재정의 메소드

        public override void OnClick()
        {
            HeroSystem.Instance.Attack.Attack();
        }

        #endregion
    }
}
