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
    /// 개요 : <para></para>
    /// 
    /// </summary>
    #endregion
    public class EquipItemSlot : MonoBehaviour
    {
        #region 필드

        [SerializeField] Image icon;
        [SerializeField] Text tier;
        [SerializeField] Text count;

        #endregion

        #region 속성

        public Image Icon => icon;
        public Text Tier => tier;
        public Text Count => count;

        #endregion
    }
}
