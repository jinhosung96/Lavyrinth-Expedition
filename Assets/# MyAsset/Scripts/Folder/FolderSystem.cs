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
    public class FolderSystem : JHS.SystemObject<FolderSystem>
    {
        #region 필드

        [SerializeField] Transform monsterFolder;
        [SerializeField] Transform backgroundFolder;

        #endregion

        #region 속성

        public Transform MonsterFolder => monsterFolder;
        public Transform BackgroundFolder => backgroundFolder;

        #endregion
    }
}
