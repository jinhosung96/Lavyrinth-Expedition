using System.Collections;
using System.Collections.Generic;
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
    public class HeroSystem : JHS.SystemObject<HeroSystem>
    {
        #region 필드

        [SerializeField] GameObject heroGO;
        Transform heroTr;
        HeroAttack attack;
        Animator animator;

        #endregion

        #region 속성

        public GameObject HeroGO => heroGO;

        public Transform HeroTr
        {
            get
            {
                if (heroTr == null) heroTr = heroGO.transform;
                return heroTr;
            }
        }

        public HeroAttack Attack
        {
            get
            {
                if (attack == null) attack = heroGO.GetComponent<HeroAttack>();
                return attack;
            }
        }

        public Animator Animator
        {
            get
            {
                if (animator == null) animator = heroGO.GetComponent<Animator>();
                return animator;
            }
        }

        #endregion
    }
}
