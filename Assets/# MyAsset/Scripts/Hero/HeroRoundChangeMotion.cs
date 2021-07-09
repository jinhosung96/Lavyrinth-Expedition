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
    public class HeroRoundChangeMotion : MonoBehaviour, IRoundChangeMotion
    {
        #region 공개 메소드

        public void StartRoundChange()
        {
            HeroSystem.Instance.Animator.SetTrigger("DoRun");
        }

        public void EndRoundChange()
        {
            HeroSystem.Instance.Animator.ResetTrigger("DoAttack");
            HeroSystem.Instance.Animator.SetTrigger("DoReset");
        }

        #endregion
    }
}
