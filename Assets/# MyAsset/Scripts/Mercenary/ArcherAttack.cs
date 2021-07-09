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
    public class ArcherAttack : MercenaryAttack
    {
        #region 필드



        #endregion

        #region 속성



        #endregion

        #region 유니티 생명주기



        #endregion

        #region 재정의 메소드

        public override void AttackStart()
        {
            HeroSystem.Instance.CurrentTarget.CurrentHP -= BigInteger.Parse(attackDamage);
        }

        #endregion

        #region 내부 메소드



        #endregion

    }
}
