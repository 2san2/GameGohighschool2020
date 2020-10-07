using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D m_Rigidbody2D;
    public float m_MovementSpeed = 5f;
    public float m_JumpSpeed = 10f;
    public float m_JumpCount = 0;

    private void FixedUpdate()
    {
        var xAxis = Input.GetAxis("Horizontal");
        var yAxis = Input.GetAxis("Vertical");

        Vector2 velocity = m_Rigidbody2D.velocity;
        velocity.x = xAxis * m_MovementSpeed;

        if (yAxis > 0.1f && m_JumpCount < 1)
        {
            velocity.y = m_JumpSpeed;
            m_JumpCount++;
        }
        m_Rigidbody2D.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            m_JumpCount = 0;
        }
    }
}