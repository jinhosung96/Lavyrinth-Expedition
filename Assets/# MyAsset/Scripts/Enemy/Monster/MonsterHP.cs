using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using System;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.UI;
using DG.Tweening;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 마물의 체력을 관리<para></para>
    /// 
    /// </summary>
    #endregion
    public class MonsterHP : EnemyHP
    {
        #region 재정의 메소드
        
        protected override string GetEventName() => "KillMonster";

        protected override HPBar GetHPBar() => HPBarSystem.Instance.MonsterHPBar;

        protected override BigInteger GetRoundHP() => StageSystem.Instance.RoundHP;

        protected override BigInteger GetRoundGold() => StageSystem.Instance.RoundGold;

        protected override float GetPropByLooting() => 0.08f;

        #endregion
    }
}
