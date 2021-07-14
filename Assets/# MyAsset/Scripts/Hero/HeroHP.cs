using DG.Tweening;
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
    public class HeroHP : BigIntegerHPFrame
    {
        #region 필드

        Animator animator;
        [SerializeField] AudioClip hitSound;
        [SerializeField] AudioClip deathSound;
        [SerializeField] string maxHP;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        #endregion

        #region 공개 메소드

        public void ResetHP()
        {
            MaxHP = BigInteger.Parse(maxHP);
            m_currentHP = MaxHP;

            // 체력바 갱신
            HPBarSystem.Instance.HeroHPBar.ResetHPBar();
        }

        #endregion

        #region 재정의 메소드

        protected override void OnSpawn()
        {
            
        }

        protected override void OnTakeDamage(BigInteger delta)
        {

        }

        protected override void OnDeath(BigInteger delta)
        {
            // Death 애니메이션 출력
            animator.SetTrigger("DoDeath");
            // 다음 라운드 시작
            StartCoroutine(Co_ChangeRound());
        }

        protected override void RefreshUIElement()
        {
            HPBarSystem.Instance.HeroHPBar.RefreshHPBar(CurrentHP, MaxHP);
        }

        #endregion

        #region 내부 메소드

        IEnumerator Co_ChangeRound()
        {
            bool IsAnimationExit() => animator.GetCurrentAnimatorStateInfo(0).IsName("Death")
                && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f - animator.GetAnimatorTransitionInfo(0).duration;

            while (!IsAnimationExit()) yield return null;

            ObserverSystem.Instance.PostNofication("DeathHero");
        }

        #endregion
    }
}
