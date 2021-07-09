using System.Collections;
using System.Collections.Generic;
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
    public class MercenarySystem : JHS.SystemObject<MercenarySystem>
    {
        #region 필드

        [SerializeField] GameObject currentWarrior;
        [SerializeField] GameObject currentArcher;
        [SerializeField] GameObject currentMage;

        #endregion

        #region 속성

        public GameObject CurrentWarrior => currentWarrior;
        public GameObject CurrentArcher => currentArcher;
        public GameObject CurrentMage => currentMage;

        #endregion
    }
}
