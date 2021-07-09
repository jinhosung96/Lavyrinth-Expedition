using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

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
    public class DamageTextSystem : JHS.SystemObject<DamageTextSystem>
    {
        #region 필드

        [SerializeField] GameObject damageText;
        [SerializeField] Transform damageTextPool;
        [SerializeField] Vector3 damageTextStartPos;
        [SerializeField] Vector3 damageTextEndPos;
        [SerializeField] float damageTextJumpPower;
        [SerializeField] float damageTextJumpDuration;

        #endregion

        #region 공개 메소드

        public void PopDamageText(BigInteger value)
        {
            GameObject damage = PoolManager.Instance.PopObject(damageText);
            damage.transform.SetParent(damageTextPool);
            damage.transform.localScale = Vector3.one;
            damage.transform.localPosition = damageTextStartPos;
            damage.GetComponent<Text>().text = $"{value.GetRoughNumber()}{value.GetUnit()}";
            damage.transform.DOLocalJump(damageTextEndPos, damageTextJumpPower, 1, damageTextJumpDuration).OnComplete(() => PoolManager.Instance.PushObject(damage));
        }

        #endregion
    }
}
