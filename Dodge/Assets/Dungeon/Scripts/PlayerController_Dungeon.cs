using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Dungeon : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public float m_Speed = 10f;

    private void Update()
    {
        float xAis = Input.GetAxis("Horizontal");
        float zAis = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(xAis, 0, zAis) * m_Speed;//rigidbody를 이용한 이동처리
       // Debug.Log(velocity);
        m_Rigidbody.velocity = velocity; 
        //transform.position = transform.position + movement; 
    }

    public void Die()
    {
        GameManeger_Dungeon gameManeger = FindObjectOfType<GameManeger_Dungeon>();
        gameManeger.ReturnToStartPoint();
    }
}
