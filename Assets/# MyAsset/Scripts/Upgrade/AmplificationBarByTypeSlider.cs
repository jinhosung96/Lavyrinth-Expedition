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
    public class AmplificationBarByTypeSlider : SliderFrame
    {
        #region 필드

        [SerializeField] UnitType type;

        #endregion

        #region 재정의 메소드

        protected override float InputValue()
        {
            if (type == UnitType.Hero) return (float)(HeroSystem.Instance.Hero.Lv % HeroSystem.Instance.Hero.IntervalLevel) / HeroSystem.Instance.Hero.IntervalLevel;
            else return (float)(MercenarySystem.Instance.Mercenaries[(int)type].Lv % MercenarySystem.Instance.Mercenaries[(int)type].IntervalLevel) / MercenarySystem.Instance.Mercenaries[(int)type].IntervalLevel;
        }

        #endregion
    }
}
