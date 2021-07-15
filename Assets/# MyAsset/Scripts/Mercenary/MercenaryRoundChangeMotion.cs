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
    public class MercenaryRoundChangeMotion : MonoBehaviour, IRoundChangeMotion
    {
        #region 필드

        [SerializeField] Animator animator;
        [SerializeField] float jumpPower;
        [SerializeField] float jumpDuration;
        [SerializeField] float jumpDelay;

        Vector3 originPos;

        #endregion

        #region 유니티 생명주기

        private void OnEnable()
        {
            originPos = transform.position;
        }

        #endregion

        #region 공개 메소드

        public void StartRoundChange()
        {
            animator.SetTrigger("DoRun");
            StartCoroutine(Co_DelayJump());
        }

        public void EndRoundChange()
        {
            animator.SetTrigger("DoReset");
        }

        #endregion

        #region 내부 메소드

        IEnumerator Co_DelayJump()
        {
            yield return new WaitForSeconds(jumpDelay);
            transform.DOJump(originPos, jumpPower, 1, jumpDuration);
        }

        #endregion
    }
}
