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

        #region 재정의 메소드

        protected override void OnSpawn()
        {
            MaxHP = BigInteger.Parse(maxHP);
            m_currentHP = MaxHP;

            // 체력바 갱신
            HPBarSystem.Instance.MonsterHPBar.value = 1;

            // 용사의 현재 타겟을 자기자신으로 갱신
            HeroSystem.Instance.CurrentTarget = this;
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
            // 다음 몬스터 출현
            print("Death");
        }

        protected override void RefreshUIElement()
        {
            int currentHPLength = CurrentHP.ToString().Length;
            int maxHPLength = MaxHP.ToString().Length;
            if (maxHPLength > 4)
            {
                int offset = maxHPLength - currentHPLength;

                if (offset < 4)
                {
                    HPBarSystem.Instance.MonsterHPBar.value = float.Parse(CurrentHP.ToString().Substring(0, 4 - offset)) / float.Parse(MaxHP.ToString().Substring(0, 4));
                }
                else HPBarSystem.Instance.MonsterHPBar.value = 0;

            }
            else HPBarSystem.Instance.MonsterHPBar.value = float.Parse(CurrentHP.ToString()) / float.Parse(MaxHP.ToString());
        }

        #endregion

        #region 내부 메소드



        #endregion
    }
}
