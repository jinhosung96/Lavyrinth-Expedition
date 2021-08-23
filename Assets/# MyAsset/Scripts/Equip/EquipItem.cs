using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JHS
{
    [System.Serializable]
    public class EquipItemDef
    {
        #region 필드

        [SerializeField] string name;
        [SerializeField] Image icon;

        #endregion

        #region 속성

        public string Name => name;
        public Image Icon => icon;

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
    [System.Serializable]
    public class EquipItem
    {
        #region 필드

        [SerializeField] EquipItemDef def;
        [SerializeField] private int count;

        #endregion

        #region 속성

        /// <summary>
        /// 해당 아이템의 정의 반환
        /// </summary>
        public EquipItemDef Def => def;
        public int Count { get => count; private set => count = value; }

        #endregion

        #region 외부 메소드

        public void Looting()
        {
            Count++;
        }

        #endregion
    }
}
