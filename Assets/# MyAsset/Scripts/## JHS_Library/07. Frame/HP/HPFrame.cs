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
    public abstract class HPFrame : MonoBehaviour
    {
        #region 필드

        [SerializeField, LabelName("최대 체력")] float m_maxHP;

        float m_currentHP;

        #endregion

        #region 속성

        public float MaxHP => m_maxHP;

        public float CurrentHP
        {
            get => m_currentHP;
            set
            { 
                if (m_currentHP > value && m_currentHP <= 0) return;                    // 이미 체력이 0 이하인데 데미지를 입을 시
                float delta = Mathf.Abs(m_currentHP - value);
                if (m_currentHP < value) OnHeal(delta);                                 // 체력이 회복 됬을 시
                if (m_currentHP > value && value > 0) OnTakeDamage(delta);              // 데미지를 입었지만 죽지 않았을 시
                m_currentHP = Mathf.Clamp(value, 0, MaxHP); RefreshUIElement();         // HP 변동치 적용
                if (m_currentHP <= 0) OnDeath();                                        // 체력 0 이하 시 사망
            }
        }

        #endregion

        #region 유니티 생명주기

        private void OnEnable()
        {
            m_currentHP = MaxHP;
            OnSpawn();
        }

        #endregion

        #region 가상 메소드

        protected virtual void OnSpawn() { }

        protected virtual void OnTakeDamage(float delta) { }

        protected virtual void OnHeal(float delta) { }

        protected virtual void RefreshUIElement() { }

        protected virtual void OnDeath() { }

        #endregion
    }
}
