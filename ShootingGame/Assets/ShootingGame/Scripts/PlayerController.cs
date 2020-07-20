using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
   
    void Update()
    {


        //float MoveX = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        //float MoveY = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        
        
        if(Input.GetKey(KeyCode.UpArrow))
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
        
        
    }
}
