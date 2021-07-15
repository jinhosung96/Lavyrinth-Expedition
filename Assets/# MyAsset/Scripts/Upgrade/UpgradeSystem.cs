using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace JHS
{
    [System.Serializable]
    public class UpgradeInfo
    {
        #region 필드

        public int increaseLv;
        public bool canPurchase;
        public BigInteger cost;
        public BigInteger increaseDPS;

        #endregion
    }

    public enum UnitType
    {
        Hero = -1,
        Warrior = 0,
        Archer = 1,
        Mage = 2
    }

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : <para></para>
    /// 
    /// </summary>
    #endregion
    public class UpgradeSystem : JHS.SystemObject<UpgradeSystem>
    {
        #region 필드

        const int amplificationDPS= 2;
        const int intervalLevel = 20;
        [SerializeField] float increaseDPS;
        [SerializeField] float increaseCost;
        [SerializeField] int upgradeSize = 1;

        #endregion

        #region 속성

        public int UpgradeSize
        {
            get => upgradeSize; set
            {
                upgradeSize = value;
                ObserverSystem.Instance.PostNofication("UpgradeSize 갱신");
            }
        }

        #endregion

        #region 공개 메소드

        public BigInteger GetDPSByLevel(BigInteger initDPS, int lv) => lv == 0 ? 0 : initDPS * (BigInteger)(Math.Pow(increaseDPS, lv - 1) * 1000000) / 1000000 * BigInteger.Pow(amplificationDPS, (int)(lv / intervalLevel));

        public BigInteger GetCostByLevel(BigInteger initCost, int lv) => initCost * (BigInteger)(Math.Pow(increaseCost, lv - 1) * 1000000) / 1000000;

        #endregion

        #region 유니티 생명주기

        protected override void Awake()
        {
            base.Awake();
            ObserverSystem.Instance.AddListener("UpgradeSize 갱신", gameObject, SetUpgradeInfo);
            ObserverSystem.Instance.AddListener("Gold 갱신", gameObject, SetUpgradeInfo);
            SetUpgradeInfo();
        }

        #endregion

        #region 내부 메소드

        void SetUpgradeInfo()
        {
            HeroSystem.Instance.SetUpgradeInfo();
            MercenarySystem.Instance.SetUpgradeInfo();
            ObserverSystem.Instance.PostNofication("UpgradeInfo 갱신");
        }

        #endregion
    }
}
