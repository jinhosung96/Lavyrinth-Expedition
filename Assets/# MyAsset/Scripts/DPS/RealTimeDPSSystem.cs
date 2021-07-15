using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UniRx;
using UniRx.Triggers;
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
    public class RealTimeDPSSystem : JHS.SystemObject<RealTimeDPSSystem>
    {
        #region 필드

        BigInteger dps;
        Subject<BigInteger> dpsStream;

        #endregion

        #region 속성

        public BigInteger DPS
        {
            get => dps; private set
            {
                dps = value;
                ObserverSystem.Instance.PostNofication("DPS 갱신");
            }
        }

        #endregion

        #region 유니티 생명주기

        private void Start()
        {
            dpsStream = new Subject<BigInteger>();
            dpsStream
                .Buffer(TimeSpan.FromSeconds(1f))
                .Select(x =>
                {
                    BigInteger sum;
                    for (int i = 0; i < x.Count; i++)
                    {
                        sum += x[i];
                    }
                    return sum;
                })
                .Scan((x, y) => (x + y) / 2)
                .Subscribe(x => DPS = x);
        }

        #endregion

        #region 공개 메소드

        public void OnNext(BigInteger damage)
        {
            dpsStream.OnNext(damage);
        }

        #endregion
    }
}
