using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Bullet bullet;
    public float CreateTime;
    void Update()
    {

        CreateTime += Time.deltaTime;
        //float MoveX = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        //float MoveY = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;


        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 1, 0) * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, 1, 0) * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(1, 0, 0) * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0) * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && CreateTime > 0.3)
        {
            var san = GameObject.Instantiate(bullet);
            var san2 = GameObject.Instantiate(bullet);
            var san3 = GameObject.Instantiate(bullet);
            san.transform.position = transform.position + new Vector3(0, 2, 0);
            san.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 30);
            san2.transform.position = transform.position + new Vector3(0, 2, 0);
            san2.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -30);
            san3.transform.position = transform.position + new Vector3(0, 2, 0);
            CreateTime = 0;



        }
        
    }
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Die",true);
    }
}
