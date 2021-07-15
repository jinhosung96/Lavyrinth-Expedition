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
    public class BossHP : EnemyHP
    {
        #region 재정의 메소드

        protected override string GetEventName() => "KillBoss";

        protected override HPBar GetHPBar() => HPBarSystem.Instance.BossHPBar;

        protected override BigInteger GetRoundHP() => StageSystem.Instance.RoundHP * 3;

        protected override BigInteger GetRoundGold() => StageSystem.Instance.RoundGold * 3;

        #endregion
    }
}
