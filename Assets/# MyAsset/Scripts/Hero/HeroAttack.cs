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
    /// 개요 : 용사의 공격을 정의 <para></para>
    /// 
    /// </summary>
    #endregion
    public class HeroAttack : MonoBehaviour
    {
        #region 필드

        [SerializeField] AudioClip[] attackSounds;

        #endregion

        #region 공개 메소드

        public void Attack()
        {
            HeroSystem.Instance.Animator.SetTrigger("DoAttack");
        }

        public void AttackStart()
        {
            HeroSystem.Instance.CurrentTarget.CurrentHP -= HeroSystem.Instance.AttackDamage;
            SoundSystem.Instance.PlaySoundEffect(attackSounds[(int)(Random.value * attackSounds.Length)]);
        }

        #endregion
    }
}
