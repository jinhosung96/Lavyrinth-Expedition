using DG.Tweening;
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
    public class LootingSystem : SystemObject<LootingSystem>
    {
        #region 필드

        [SerializeField] GameObject lootingItem;
        [SerializeField] Transform lootingItemPool;
        [SerializeField] Vector3 lootingItemStartPos;
        [SerializeField] Vector3 lootingItemEndPos;
        [SerializeField] float duration;

        #endregion

        #region 공개 메소드

        public void Looting(EquipItem item)
        {
            item.Count++;
            GameObject itemObj = PoolManager.Instance.PopObject(lootingItem);
            itemObj.transform.SetParent(lootingItemPool);
            itemObj.transform.localScale = Vector3.one;
            itemObj.GetComponent<Image>().sprite = item.Def.Icon;
            itemObj.transform.localPosition = lootingItemStartPos;
            itemObj.transform.DOLocalMove(lootingItemEndPos, duration).OnComplete(() => PoolManager.Instance.PushObject(itemObj));
        }

        #endregion
    }
}
