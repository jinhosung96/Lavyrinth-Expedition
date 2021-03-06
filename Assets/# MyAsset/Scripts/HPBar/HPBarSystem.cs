using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : HPBar들을 관리 <para></para>
    /// 
    /// </summary>
    #endregion
    public class HPBarSystem : JHS.SystemObject<HPBarSystem>
    {
        #region 필드

        [SerializeField] GameObject monsterHPBarGO;
        [SerializeField] GameObject bossAndHeroHPBarGO;
        [SerializeField] HPBar monsterHPBar;
        [SerializeField] HPBar bossHPBar;
        [SerializeField] HPBar heroHPBar;

        #endregion

        #region 속성

        public GameObject MonsterHPBarGO => monsterHPBarGO;
        public GameObject BossAndHeroHPBarGO => bossAndHeroHPBarGO;
        public HPBar MonsterHPBar => monsterHPBar;
        public HPBar BossHPBar => bossHPBar;
        public HPBar HeroHPBar => heroHPBar;

        #endregion
    }
}
