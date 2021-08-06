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
    public abstract class MercenaryAttack : MonoBehaviour
    {
        #region 필드

        [SerializeField] protected int type;
        [SerializeField] Animator animator;
        [SerializeField] protected AudioClip[] attackSounds;

        #endregion

        #region 유니티 생명주기

        private void OnEnable()
        {
            StartCoroutine(Co_Attack());
        }

        #endregion

        #region 추상 메소드

        public abstract void AttackStart();

        #endregion

        #region 내부 메소드

        private IEnumerator Co_Attack()
        {
            bool IsTarget() => HeroSystem.Instance.CurrentTarget != null && HeroSystem.Instance.CurrentTarget.CurrentHP > 0;
            while (true)
            {
                yield return new WaitForSeconds(1 / MercenarySystem.Instance.Mercenaries[type].AttackSpeed);
                while (!IsTarget()) yield return null;

                Attack();
            }
        }

        void Attack()
        {
            animator.SetTrigger("DoAttack");
        }

        #endregion
    }
}
