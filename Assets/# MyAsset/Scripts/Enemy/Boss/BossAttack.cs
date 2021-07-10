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
    public class BossAttack : MonoBehaviour
    {
        #region 필드

        Animator animator;
        [SerializeField] string attackDamage;
        [SerializeField] float attackDelay;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        void OnEnable()
        {
            StartCoroutine(Co_Attack());
        }

        #endregion

        #region 공개 메소드

        public void Attack()
        {
            animator.SetTrigger("DoAttack");
        }

        public void AttackStart()
        {
            HeroSystem.Instance.HeroHP.CurrentHP -= BigInteger.Parse(attackDamage);
        }

        #endregion

        #region 내부 메소드

        IEnumerator Co_Attack()
        {
            while (true)
            {
                yield return new WaitForSeconds(attackDelay);
                Attack();
            }
        }

        #endregion
    }
}
