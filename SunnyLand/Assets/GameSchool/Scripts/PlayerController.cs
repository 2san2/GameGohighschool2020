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
    public bool m_isTouchLadder = false;
    public bool m_isClimbing = false;
    public float m_ClimbSpeed = 2f;

    protected void Start()
    {
      m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }
    protected void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        if(m_isTouchLadder && Mathf.Abs(yAxis) > 0.5f)
        {
            m_isClimbing = true;
        }
        

        if(!m_isClimbing)
        {

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
            if (Input.GetKeyDown(KeyCode.LeftArrow))
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
        else
        {
            m_Rigidbody2D.constraints = m_Rigidbody2D.constraints | RigidbodyConstraints2D.FreezePosition;

            Vector3 movement = Vector3.zero;
            movement.x = xAxis * Time.deltaTime * m_ClimbSpeed;
            movement.y = yAxis * Time.deltaTime * m_ClimbSpeed;

            transform.position += movement;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ClimbingExit();
            }

            m_Animator.SetBool("isClimbing", m_isClimbing);
            m_Animator.SetFloat("ClimbSpeed", Mathf.Abs(xAxis) + Mathf.Abs(yAxis));
        }

    }
    private void ClimbingExit()
    {
        m_Rigidbody2D.constraints = m_Rigidbody2D.constraints & ~RigidbodyConstraints2D.FreezePosition;
        m_isClimbing = false;

        m_Animator.SetBool("isClimbing", m_isClimbing);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            m_JumpCount = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            m_isTouchLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            m_isTouchLadder = false;
            ClimbingExit();
        }
    }

}
