using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody2D))]
public class HPComponent : MonoBehaviour
{
    public float m_Hp = 30;
    public UnityEvent m_OnDie;
    public UnityEvent m_OnTakeDamage;
    public UnityEvent m_OnTakeHeal;

    public virtual void TakeDamage(int damage)
    {
        m_Hp -= damage;
        m_OnTakeDamage.Invoke();

        if (m_Hp <= 0)
        {
            m_OnDie.Invoke();
        }
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
