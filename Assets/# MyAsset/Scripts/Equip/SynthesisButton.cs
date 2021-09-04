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
    public class SynthesisButton : ButtonClick
    {
        #region 필드

        EquipItemType type;
        int tier;

        #endregion

        #region 속성

        public EquipItemType Type { get => type; set => type = value; }
        public int Tier { get => tier; set => tier = value; }

        #endregion

        #region 재정의 메소드

        public override void OnClick()
        {
            if (EquipSystem.Instance.EquipItemList[Type].Totals.Length - 1 == Tier) return;

            if (EquipSystem.Instance.EquipItemList[Type].Totals[Tier].Count >= EquipSystem.Instance.SynthesisCount)
            {
                EquipSystem.Instance.EquipItemList[Type].Totals[Tier].Count -= EquipSystem.Instance.SynthesisCount;
                EquipSystem.Instance.EquipItemList[Type].Totals[Tier + 1].Count++;
            }
        }

        #endregion
    }
}
