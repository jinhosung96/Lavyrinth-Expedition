using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public abstract class NestedScrollRectFrame : ScrollRect
    {
        #region 필드

        bool forParent;

        #endregion

        #region 속성

        public abstract ScrollRect ParentScrollRect { get; }

        #endregion

        #region 내부 메소드

        public override void OnBeginDrag(PointerEventData eventData)
        {
            forParent = Mathf.Abs(eventData.delta.x) < Mathf.Abs(eventData.delta.y);

            if (forParent) ParentScrollRect.OnBeginDrag(eventData);
            else base.OnBeginDrag(eventData);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            if (forParent) ParentScrollRect.OnDrag(eventData);
            else base.OnDrag(eventData);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            if (forParent) ParentScrollRect.OnEndDrag(eventData);
            else base.OnEndDrag(eventData);
        }

        #endregion
    }
}
