using DG.Tweening;
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
    public class EnemyRoundStartMotion : MonoBehaviour, IRoundChangeMotion
    {
        #region 공개 메소드

        public void StartRoundChange()
        {
            transform.DOMoveX(transform.position.x - 7.8f, StageSystem.Instance.RoundChangeDelay);
        }

        public void EndRoundChange()
        {
            EnemyHP hp = GetComponent<EnemyHP>();
            hp.ChangeTarget();
            if(hp is MonsterHP)
            {
                HPBarSystem.Instance.BossAndHeroHPBarGO.SetActive(false);
                HPBarSystem.Instance.MonsterHPBarGO.SetActive(true);
            }
            else
            {
                HPBarSystem.Instance.MonsterHPBarGO.SetActive(false);
                HPBarSystem.Instance.BossAndHeroHPBarGO.SetActive(true);
            }

        }

        #endregion
    }
}
