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
        [SerializeField] int upgrade;
        [SerializeField] string initDPS;
        [SerializeField] float attackSpeed;
        MercenaryRoundChangeMotion changeMotion;

        #endregion

        #region 속성

        public GameObject Obj => obj;
        public BigInteger DPS => BigInteger.Parse(initDPS) * Upgrade * (int)Mathf.Pow(2, (int)(Upgrade / 10));
        public BigInteger AttackDamage => DPS * (int)(AttackSpeed * 100) / 100;
        public float AttackSpeed => attackSpeed;
        public MercenaryRoundChangeMotion ChangeMotion => changeMotion ? changeMotion : changeMotion = obj.GetComponent<MercenaryRoundChangeMotion>();

        public int Upgrade { get => upgrade; set => upgrade = value; }

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
    }
}
