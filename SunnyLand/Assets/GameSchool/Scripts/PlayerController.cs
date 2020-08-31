using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform m_Sprite;
    public float m_JumpCount = 0;

    private Rigidbody2D m_Rigidbody2D;
    private Animator m_Animator;

    public float m_XAxisSpeed = 3f;
    public float m_YJumpPower = 3f;
    public bool m_isJumping = false;

    protected void Start()
    {
      m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }
    protected void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector2 velocity = m_Rigidbody2D.velocity;
        velocity.x = xAxis * m_XAxisSpeed;
        m_Rigidbody2D.velocity = velocity;
        if (Input.GetKeyDown(KeyCode.Space) && m_JumpCount < 2)
        {
            m_Rigidbody2D.AddForce(Vector3.up * m_YJumpPower);
            m_JumpCount++;
        }
       if (Input.GetKeyDown(KeyCode.RightArrow))
       {
         gameObject.transform.localScale = new Vector3(1, 1, 1);
       }
       if(Input.GetKeyDown(KeyCode.LeftArrow))
       {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
       }
       if (Input.GetKeyDown(KeyCode.A))
       {
           gameObject.transform.localScale = new Vector3(-1, 1, 1);
       }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        var animator = GetComponent<Animator>();
        animator.SetFloat("VelocityY", velocity.y);
        //  else if (xAxis < 0) 
        // {
        //   }
        m_Animator.SetBool("isJumping", m_isJumping);
        m_Animator.SetFloat("VelocityX", Mathf.Abs(xAxis));
        m_Animator.SetFloat("VelocityY", velocity.y);
        m_isJumping = Mathf.Abs(velocity.y) >= 0.1f ? true : false; //if랑 비슷 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            m_JumpCount = 0;
        }
    }
}
