using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using System;

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
        [SerializeField] string maxHP;

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

            MaxHP = BigInteger.Parse(maxHP);
            m_currentHP = MaxHP;
        }

        protected override void OnTakeDamage(BigInteger delta)
        {
            // Hit 애니메이션 출력
            animator.SetTrigger("DoHit");
            // Hit 사운드 출력
            //SoundSystem.Instance.PlaySoundEffect(hitSound);
            // 플로팅 데미지 출력
        }

        protected override void OnDeath()
        {
            // Death 애니메이션 출력
            animator.SetTrigger("DoDeath");
            // Death 사운드 출력
            //SoundSystem.Instance.PlaySoundEffect(deathSound);
            // 골드 드랍
            // 다음 라운드 시작
            StageSystem.Instance.ChangeRound();            
        }

        protected override void RefreshUIElement()
        {
            HPBarSystem.Instance.MonsterHPBar.RefreshHPBar(CurrentHP, MaxHP);
        }

        #endregion

        #region 내부 메소드



        #endregion
    }
}
