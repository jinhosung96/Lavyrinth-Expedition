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
    public class SynthesisButton : ButtonClick
    {
        #region 필드

        EquipItem item;

        #endregion

        #region 속성

        public EquipItem Item { get => item; set => item = value; }

        #endregion

        #region 재정의 메소드

        public override void OnClick()
        {
            Item.Synthesis();
        }

        #endregion
    }
}
