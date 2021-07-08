using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace JHS
{
    #region Timer

    public class Timer
    {
        #region 속성

        public float SetTime { get; private set; }
        public float Time { get; private set; }
        public Action OnStart { get; set; } = null;
        public Action OnCount { get; set; } = null;
        public Action OnReset { get; set; } = null;
        public Action OnExtend { get; set; } = null;
        public Action OnStop { get; set; } = null;
        public Action OnEnd { get; set; } = null;
        public bool IsStop { get; set; } = false;
        public bool IsRun { get; set; } = false;

        #endregion

        #region 생성자

        public Timer(float setTime)
        {
            SetTime = setTime;
            Time = SetTime;
        }

        #endregion

        #region 공개 메소드

        public void ResetTimer()
        {
            Time = SetTime;
            IsRun = false;
            IsStop = false;
        }

        public void AddTime(float addTime)
        {
            Time += addTime;
        }

        #endregion
    } 

    #endregion

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 타이머 기능을 관리하는 객체  <para></para>
    ///
    /// </summary>
    #endregion
    public class TimerSystem : SystemObject<TimerSystem>
    {
        #region 필드

        Dictionary<string, Timer> m_timers = new Dictionary<string, Timer>();

        #endregion

        #region 공개 메소드

        /// <summary>
        /// 해당 이름의 타이머를 초기화한다.
        /// </summary>
        /// <param name="name"> 타이머 이름 </param>
        /// <param name="newTimer"> 초기화할 대상 </param>
        public void SetTimer(string name, Timer newTimer)
        {
            if (!m_timers.ContainsKey(name)) m_timers.Add(name, newTimer);
            else m_timers[name] = newTimer;
        }
        
        /// <summary>
        /// 해당 이름의 타이머를 가져온다.
        /// </summary>
        /// <param name="name"> 타이머 이름 </param>
        /// <returns></returns>
        public Timer GetTimer(string name)
        {
            Assert.IsTrue(m_timers.ContainsKey(name), "해당 이름의 타이머가 없습니다");
            return m_timers[name];
        }

        /// <summary>
        /// 해당 이름의 타이머를 작동시킨다.
        /// </summary>
        /// <param name="name"> 타이머 이름 </param>
        public void StartTimer(string name)
        {
            Assert.IsTrue(m_timers.ContainsKey(name), "해당 이름의 타이머가 없습니다");

            if (!m_timers[name].IsRun)
            {
                m_timers[name].IsRun = true;
                m_timers[name].IsStop = false;

                StartCoroutine(Co_Timer(name));
            }
            else m_timers[name].IsStop = false;

            m_timers[name].OnStart();
        }

        /// <summary>
        /// 해당 이름의 타이머를 리셋시킨다.
        /// </summary>
        /// <param name="name"> 타이머 이름 </param>
        public void ResetTimer(string name)
        {
            Assert.IsTrue(m_timers.ContainsKey(name), "해당 이름의 타이머가 없습니다");

            m_timers[name].ResetTimer();
            m_timers[name].OnReset();
        }

        /// <summary>
        /// 해당 이름의 타이머를 연장시킨다.
        /// </summary>
        /// <param name="name"> 타이머 이름 </param>
        /// <param name="addTime"> 추가할 시간(초) </param>
        public void ExtendTimer(string name, float addTime)
        {
            Assert.IsTrue(m_timers.ContainsKey(name), "해당 이름의 타이머가 없습니다");
            m_timers[name].AddTime(addTime);
            m_timers[name].OnExtend();
        }

        /// <summary>
        /// 해당 이름의 타이머를 일시 중지시킨다.
        /// </summary>
        /// <param name="name"> 타이머 이름 </param>
        public void StopTimer(string name)
        {
            Assert.IsTrue(m_timers.ContainsKey(name), "해당 이름의 타이머가 없습니다");
            m_timers[name].IsStop = true;
            m_timers[name].OnStop();
        }

        #endregion

        #region 내부 메소드

        IEnumerator Co_Timer(string name)
        {
            yield return null;
            while (m_timers[name].IsRun)
            {
                m_timers[name].AddTime(-Time.deltaTime);
                m_timers[name].OnCount();

                if (m_timers[name].Time < 0)
                {
                    m_timers[name].IsRun = false;
                    ResetTimer(name);
                    m_timers[name].OnEnd();
                }

                while (m_timers[name].IsStop && m_timers[name].IsRun) yield return null;

                yield return null;
            }
        }

        #endregion
    }
}
