using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace JHS
{
    [System.Serializable]
    public class Mercenary
    {
        #region 필드

        [SerializeField] GameObject obj;
        [SerializeField] string name;
        int lv;
        [SerializeField] string initDPS;
        [SerializeField] string initCost;
        [SerializeField] float attackSpeed;
        MercenaryRoundChangeMotion changeMotion;
        UpgradeInfo upgradeInfo = new UpgradeInfo();

        #endregion

        #region 속성

        public GameObject Obj => obj;
        public BigInteger DPS => UpgradeSystem.Instance.GetDPSByLevel(BigInteger.Parse(initDPS), Lv);
        public BigInteger Cost => UpgradeSystem.Instance.GetCostByLevel(BigInteger.Parse(initCost), Lv);
        public BigInteger AttackDamage => DPS * (int)(AttackSpeed * 10) / 10;
        public float AttackSpeed => attackSpeed;
        public MercenaryRoundChangeMotion ChangeMotion => changeMotion ? changeMotion : changeMotion = obj.GetComponent<MercenaryRoundChangeMotion>();
        public UpgradeInfo UpgradeInfo => upgradeInfo;

        public int Lv
        {
            get => lv; set
            {
                lv = value;
                if (lv == 1) Obj.SetActive(true);
                ObserverSystem.Instance.PostNofication($"{name} 갱신");
                ObserverSystem.Instance.PostNofication($"용병 갱신");
            }
        }

        #endregion

        #region 공개 메소드

        public void SetUpgradeInfo()
        {
            BigInteger totalCost = BigInteger.Zero;

            if(true)
            {
                int nextLv = Lv;
                BigInteger tempCost = UpgradeSystem.Instance.GetCostByLevel(BigInteger.Parse(initCost), nextLv + 1);

                while (tempCost <= CurrencyData.Instance.Gold && (UpgradeSystem.Instance.UpgradeSize == -1 || nextLv - Lv < UpgradeSystem.Instance.UpgradeSize))
                {
                    totalCost = tempCost;
                    nextLv++;
                    tempCost = totalCost + UpgradeSystem.Instance.GetCostByLevel(BigInteger.Parse(initCost), nextLv + 1);
                }


                bool canPurchase = nextLv - Lv > 0;

                upgradeInfo.canPurchase = canPurchase;
                upgradeInfo.increaseLv = canPurchase ? nextLv - Lv : 1;
                upgradeInfo.cost = upgradeInfo.canPurchase ? totalCost : tempCost;
                upgradeInfo.increaseDPS = UpgradeSystem.Instance.GetDPSByLevel(BigInteger.Parse(initDPS), canPurchase ? nextLv : Lv + 1) - DPS;
            }     
        }

        #endregion
    }

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : <para></para>
    /// 
    /// </summary>
    #endregion
    public class MercenarySystem : JHS.SystemObject<MercenarySystem>                                    
    {
        #region 필드

        [SerializeField] Mercenary[] mercenaries;

        #endregion

        #region 속성

        public Mercenary[] Mercenaries => mercenaries;

        #endregion

        #region 공개 메소드

        public void SetUpgradeInfo()
        {
            for (int i = 0; i < Mercenaries.Length; i++)
            {
                Mercenaries[i].SetUpgradeInfo();
            }
        }

        #endregion
    }
}
