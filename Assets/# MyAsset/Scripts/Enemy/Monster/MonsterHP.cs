using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using System;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.UI;
using DG.Tweening;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 마물의 체력을 관리<para></para>
    /// 
    /// </summary>
    #endregion
    public class MonsterHP : BigIntegerHPFrame
    {
        #region 필드

        [SerializeField] Animator animator;
        [SerializeField] AudioClip hitSound;
        [SerializeField] AudioClip deathSound;

        #endregion

        #region 공개 메소드

        public void ChangeTarget()
        {
            // 체력바 갱신
            HPBarSystem.Instance.MonsterHPBar.ResetHPBar();

            // 용사의 현재 타겟을 자기자신으로 갱신
            HeroSystem.Instance.CurrentTarget = this;
        }

        #endregion

        #region 재정의 메소드

        protected override void OnSpawn()
        {
            animator.SetTrigger("DoReset");

            MaxHP = StageSystem.Instance.RoundHP;
            m_currentHP = MaxHP;
        }

        protected override void OnTakeDamage(BigInteger delta)
        {
            // Hit 애니메이션 출력
            animator.SetTrigger("DoHit");
            // Hit 사운드 출력
            //SoundSystem.Instance.PlaySoundEffect(hitSound);
            // 플로팅 데미지 출력
            DamageTextSystem.Instance.PopDamageText(delta);
        }

        protected override void OnDeath()
        {
            // Death 애니메이션 출력
            animator.SetTrigger("DoDeath");
            // Death 사운드 출력
            //SoundSystem.Instance.PlaySoundEffect(deathSound);
            // 골드 드랍
            CurrencyData.Instance.Gold += StageSystem.Instance.RoundGold;
            // 다음 라운드 시작
            StartCoroutine(Co_ChangeRound());
        }

        protected override void RefreshUIElement()
        {
            HPBarSystem.Instance.MonsterHPBar.RefreshHPBar(CurrentHP, MaxHP);
        }

        #endregion

        #region 내부 메소드

        IEnumerator Co_ChangeRound()
        {
            bool IsAnimationExit() => animator.GetCurrentAnimatorStateInfo(0).IsName("Death") 
                && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f - animator.GetAnimatorTransitionInfo(0).duration;

            while (!IsAnimationExit()) yield return null;

            ObserverSystem.Instance.PostNofication("KillMonster");
        }

        #endregion
    }
}
