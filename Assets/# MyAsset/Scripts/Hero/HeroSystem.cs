using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 용사에 관련된 데이터 관리 <para></para>
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
        BigIntegerHPFrame currentTarget;
        HeroRoundChangeMotion heroRoundChangeMotion;

        #endregion

        #region 속성

        public GameObject HeroGO => heroGO;
        public Transform HeroTr => heroTr == null ? heroTr = heroGO.transform : heroTr;
        public HeroAttack HeroAttack => attack == null ? attack = heroGO.GetComponent<HeroAttack>() : attack;
        public Animator Animator => animator == null ? animator = heroGO.GetComponent<Animator>() : animator;
        public HeroRoundChangeMotion HeroRoundChangeMotion => heroRoundChangeMotion == null ? heroRoundChangeMotion = heroGO.GetComponent<HeroRoundChangeMotion>() : heroRoundChangeMotion;

        public BigIntegerHPFrame CurrentTarget { get => currentTarget; set => currentTarget = value; }

        #endregion
    }
}
