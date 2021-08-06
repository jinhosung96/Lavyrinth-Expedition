using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace JHS
{
    [System.Serializable]
    public class Hero : UpgradeUnit
    {
        public override BigInteger AttackDamage => DPS / 3;
    }

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

        [SerializeField] Hero hero = new Hero();

        Transform heroTr;
        HeroAttack attack;
        Animator animator;
        BigIntegerHPFrame currentTarget;
        HeroRoundChangeMotion heroRoundChangeMotion;
        HeroHP heroHP;

        #endregion

        #region 속성

        public Hero Hero => hero;
        public GameObject HeroGO => Hero.GO;
        public Transform HeroTr => heroTr == null ? heroTr = HeroGO.transform : heroTr;
        public HeroAttack HeroAttack => attack == null ? attack = HeroGO.GetComponent<HeroAttack>() : attack;
        public Animator Animator => animator == null ? animator = HeroGO.GetComponent<Animator>() : animator;
        public HeroRoundChangeMotion HeroRoundChangeMotion => heroRoundChangeMotion == null ? heroRoundChangeMotion = HeroGO.GetComponent<HeroRoundChangeMotion>() : heroRoundChangeMotion;
        public HeroHP HeroHP => heroHP == null ? heroHP = HeroGO.GetComponent<HeroHP>() : heroHP;

        public BigIntegerHPFrame CurrentTarget { get => currentTarget; set => currentTarget = value; }

        #endregion

        #region 유니티 생명주기

        protected override void Awake()
        {
            base.Awake();
        }

        #endregion
    }
}
