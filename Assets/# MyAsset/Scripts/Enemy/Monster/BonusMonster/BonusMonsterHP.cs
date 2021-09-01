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
    public class BonusMonsterHP : MonsterHP
    {
        #region 재정의 메소드

        protected override BigInteger GetRoundHP() => StageSystem.Instance.RoundHP * 2;

        protected override BigInteger GetRoundGold() => StageSystem.Instance.RoundGold * 5;

        protected override float GetPropByLooting() => base.GetPropByLooting() * 3;

        #endregion
    }
}
