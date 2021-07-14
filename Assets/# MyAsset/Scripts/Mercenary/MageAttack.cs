using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
    public class MageAttack : MercenaryAttack
    {
        #region 재정의 메소드

        public override void AttackStart()
        {
            HeroSystem.Instance.CurrentTarget.CurrentHP -= MercenarySystem.Instance.Mercenaries[type].AttackDamage;
            SoundSystem.Instance.PlaySoundEffect(attackSounds[(int)(Random.value * attackSounds.Length)]);
        }

        #endregion
    }
}
