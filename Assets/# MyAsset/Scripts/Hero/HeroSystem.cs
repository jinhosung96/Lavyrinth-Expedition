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
    /// 개요 : 용사에 관련된 데이터 관리 <para></para>
    /// 
    /// </summary>
    #endregion
    public class HeroSystem : JHS.SystemObject<HeroSystem>
    {
        #region 필드

        [SerializeField] GameObject heroGO;
        int lv = 1;
        [SerializeField] string initDPS;
        [SerializeField] string initIncreaseDPS;
        [SerializeField] float amplificationDPS;
        [SerializeField] string initCost;
        [SerializeField] string initIncreaseCost;
        [SerializeField] float amplificationCost;
        UpgradeInfo upgradeInfo = new UpgradeInfo();

        Transform heroTr;
        HeroAttack attack;
        Animator animator;
        BigIntegerHPFrame currentTarget;
        HeroRoundChangeMotion heroRoundChangeMotion;
        HeroHP heroHP;

        #endregion

        #region 속성

        public BigInteger DPS => UpgradeSystem.Instance.GetDPSByLevel(BigInteger.Parse(initDPS), BigInteger.Parse(initIncreaseDPS), amplificationDPS, Lv);
        public BigInteger Cost => UpgradeSystem.Instance.GetCostByLevel(BigInteger.Parse(initCost), BigInteger.Parse(initIncreaseCost), amplificationCost, Lv);
        public BigInteger AttackDamage => DPS / 3;

        public int Lv
        {
            get => lv; set
            {
                lv = value;
                ObserverSystem.Instance.PostNofication($"용사 갱신");
            }
        }

        public GameObject HeroGO => heroGO;
        public Transform HeroTr => heroTr == null ? heroTr = heroGO.transform : heroTr;
        public HeroAttack HeroAttack => attack == null ? attack = heroGO.GetComponent<HeroAttack>() : attack;
        public Animator Animator => animator == null ? animator = heroGO.GetComponent<Animator>() : animator;
        public HeroRoundChangeMotion HeroRoundChangeMotion => heroRoundChangeMotion == null ? heroRoundChangeMotion = heroGO.GetComponent<HeroRoundChangeMotion>() : heroRoundChangeMotion;
        public HeroHP HeroHP => heroHP == null ? heroHP = heroGO.GetComponent<HeroHP>() : heroHP;

        public BigIntegerHPFrame CurrentTarget { get => currentTarget; set => currentTarget = value; }
        public UpgradeInfo UpgradeInfo => upgradeInfo;

        #endregion

        #region 유니티 생명주기

        protected override void Awake()
        {
            base.Awake();
        }

        #endregion

        #region 공개 메소드

        public void SetUpgradeInfo()
        {
            BigInteger totalCost = BigInteger.Zero;

            int nextLv = Lv;
            BigInteger tempCost = UpgradeSystem.Instance.GetCostByLevel(BigInteger.Parse(initCost), BigInteger.Parse(initIncreaseCost), amplificationCost, nextLv);

            while (tempCost <= CurrencyData.Instance.Gold && (UpgradeSystem.Instance.UpgradeSize == -1 || nextLv - Lv < UpgradeSystem.Instance.UpgradeSize))
            {
                totalCost = tempCost;
                nextLv++;
                tempCost = totalCost + UpgradeSystem.Instance.GetCostByLevel(BigInteger.Parse(initCost), BigInteger.Parse(initIncreaseCost), amplificationCost, nextLv);
            }

            bool canPurchase = nextLv - Lv > 0;

            upgradeInfo.canPurchase = canPurchase;
            upgradeInfo.increaseLv = canPurchase ? nextLv - Lv : 1;
            upgradeInfo.cost = upgradeInfo.canPurchase ? totalCost : tempCost;
            upgradeInfo.increaseDPS = UpgradeSystem.Instance.GetDPSByLevel(BigInteger.Parse(initDPS), BigInteger.Parse(initIncreaseDPS), amplificationDPS, canPurchase ? nextLv : Lv + 1) - DPS;
        }

        #endregion
    }
}
