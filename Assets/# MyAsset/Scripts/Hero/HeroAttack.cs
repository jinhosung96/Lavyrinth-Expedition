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

        [SerializeField] string tapDamage;

        #endregion

        #region 공개 메소드

        public void Attack()
        {
            HeroSystem.Instance.Animator.SetTrigger("DoAttack");
        }

        public void AttackStart()
        {
            HeroSystem.Instance.CurrentTarget.CurrentHP -= BigInteger.Parse(tapDamage);
        }

        #endregion
    }
}
