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
    public class AmplificationByTypeText : TextFrame
    {
        #region 필드

        [SerializeField] UnitType type;

        #endregion

        #region 재정의 메소드

        protected override string WriteText()
        {
            if (type == UnitType.Hero)
            {
                int amplificationDPS = HeroSystem.Instance.Hero.AmplificationDPS;
                int remainLevel = HeroSystem.Instance.Hero.IntervalLevel - (HeroSystem.Instance.Hero.Lv % HeroSystem.Instance.Hero.IntervalLevel);
                return $"<color=#D4D4D4>DPS</color> {amplificationDPS}<color=#D4D4D4>배 증폭까지</color> {remainLevel}<color=#D4D4D4>레벨 남음...</color>";
            }
            else
            {
                int amplificationDPS = MercenarySystem.Instance.Mercenaries[(int)type].AmplificationDPS;
                int remainLevel = MercenarySystem.Instance.Mercenaries[(int)type].IntervalLevel - (MercenarySystem.Instance.Mercenaries[(int)type].Lv % MercenarySystem.Instance.Mercenaries[(int)type].IntervalLevel);
                return $"<color=#D4D4D4>DPS</color> {amplificationDPS}<color=#D4D4D4>배 증폭까지</color> {remainLevel}<color=#D4D4D4>레벨 남음...</color>";
            }
        }

        #endregion
    }
}
