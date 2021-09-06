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
        [SerializeField] SynthesisButton button;

        #endregion

        #region 속성

        public Image Icon => icon;
        public Text Tier => tier;
        public Text Count => count;
        public SynthesisButton Button => button;
        public EquipItem Item { get; set; }

        #endregion

        #region 공개 메소드

        public void UpdateCount()
        {
            if (EquipSystem.Instance.EquipItemList[Item.Def.Type].Totals.Length - 1 != Item.Def.Tier)
            {
                Count.text = $"{Item.Count}/{EquipSystem.Instance.SynthesisCount}";
                if (Item.Count < EquipSystem.Instance.SynthesisCount) Count.color = Color.white;
                else Count.color = Color.green;
            }
            else Count.text = $"{Item.Count}";
        }

        #endregion
    }
}
