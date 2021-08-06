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
    [System.Serializable]
    public abstract class UpgradeUnit
    {
        #region 필드

        [SerializeField] int lv;

        [SerializeField] GameObject go;

        [SerializeField] string initDPS;
        [SerializeField] string initIncreaseDPS;
        [SerializeField] float increaseDPS;
        [SerializeField] int amplificationDPS;
        [SerializeField] int intervalLevel;

        [SerializeField] string initCost;
        [SerializeField] string initIncreaseCost;
        [SerializeField] float increaseCost;

        [SerializeField] string[] eventNames;

        UpgradeInfo upgradeInfo = new UpgradeInfo();

        #endregion

        #region 속성

        public GameObject GO => go;

        public int Lv
        {
            get => lv; set
            {
                lv = value;
                if (lv == 1) GO.SetActive(true);
                for (int i = 0; i < eventNames.Length; i++)
                {
                    ObserverSystem.Instance.PostNofication(eventNames[i]);
                }                
            }
        }

        public BigInteger DPS => UpgradeSystem.Instance.GetDPSByLevel(BigInteger.Parse(InitDPS), BigInteger.Parse(InitIncreaseDPS), IncreaseDPS, amplificationDPS, intervalLevel, Lv);
        public BigInteger Cost => UpgradeSystem.Instance.GetCostByLevel(BigInteger.Parse(InitCost), BigInteger.Parse(InitIncreaseCost), IncreaseCost, Lv);
        public int AmplificationDPS => amplificationDPS;
        public int IntervalLevel => intervalLevel;
        public UpgradeInfo UpgradeInfo => upgradeInfo;

        protected string InitDPS => initDPS;
        protected string InitIncreaseDPS => initIncreaseDPS;
        protected float IncreaseDPS => increaseDPS;
        protected string InitCost => initCost;
        protected string InitIncreaseCost => initIncreaseCost;
        protected float IncreaseCost => increaseCost;

        public abstract BigInteger AttackDamage { get; }

        #endregion

        #region 공개 메소드

        public void SetUpgradeInfo()
        {
            BigInteger totalCost = BigInteger.Zero;

            int nextLv = Lv;
            BigInteger tempCost = UpgradeSystem.Instance.GetCostByLevel(BigInteger.Parse(InitCost), BigInteger.Parse(InitIncreaseCost), IncreaseCost, nextLv + 1);

            while (tempCost <= CurrencyData.Instance.Gold && (UpgradeSystem.Instance.UpgradeSize == -1 || nextLv - Lv < UpgradeSystem.Instance.UpgradeSize))
            {
                totalCost = tempCost;
                nextLv++;
                tempCost = totalCost + UpgradeSystem.Instance.GetCostByLevel(BigInteger.Parse(InitCost), BigInteger.Parse(InitIncreaseCost), IncreaseCost, nextLv + 1);
            }

            bool canPurchase = nextLv - Lv > 0;

            UpgradeInfo.canPurchase = canPurchase;
            UpgradeInfo.increaseLv = canPurchase ? nextLv - Lv : 1;
            UpgradeInfo.cost = UpgradeInfo.canPurchase ? totalCost : tempCost;
            UpgradeInfo.increaseDPS = UpgradeSystem.Instance.GetDPSByLevel(BigInteger.Parse(InitDPS), BigInteger.Parse(InitIncreaseDPS), IncreaseDPS, AmplificationDPS, IntervalLevel, canPurchase ? nextLv : Lv + 1) - DPS;
        }

        #endregion
    }
}
