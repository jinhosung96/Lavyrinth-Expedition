using System.Numerics;
using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 체력을 관리하고 변동 시 기능을 정의하는 프레임 <para></para>
    /// 
    /// </summary>
    #endregion
    public abstract class BigIntegerHPFrame : MonoBehaviour
    {
        #region 필드

        BigInteger m_maxHP;
        protected BigInteger m_currentHP;

        #endregion

        #region 속성

        public BigInteger MaxHP { get => m_maxHP; protected set => m_maxHP = value; }

        public BigInteger CurrentHP
        {
            get => m_currentHP;
            set
            {
                if (m_currentHP == value) return;
                if (m_currentHP > value && m_currentHP <= 0) return;                    // 이미 체력이 0 이하인데 데미지를 입을 시
                BigInteger delta = BigInteger.Abs(m_currentHP - value);
                if (m_currentHP < value) OnHeal(delta);                                 // 체력이 회복 됬을 시
                if (m_currentHP > value && value > 0) OnTakeDamage(delta);              // 데미지를 입었지만 죽지 않았을 시
                m_currentHP = BigInteger.Max(BigInteger.Min(value, MaxHP), 0); RefreshUIElement();         // HP 변동치 적용
                if (m_currentHP <= 0) OnDeath(delta);                                        // 체력 0 이하 시 사망
            }
        }

        #endregion

        #region 유니티 생명주기

        private void OnEnable()
        {            
            OnSpawn();
        }

        #endregion

        #region 추상 메소드

        protected virtual void OnSpawn() { }

        protected virtual void OnTakeDamage(BigInteger delta) { }

        protected virtual void OnHeal(BigInteger delta) { }

        protected virtual void RefreshUIElement() { }

        protected virtual void OnDeath(BigInteger delta) { }

        #endregion
    }
}
