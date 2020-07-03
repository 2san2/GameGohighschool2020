using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject m_Bullet;
   

    public float m_RoatationSpeed = 60f;
    public float m_AttactInterval = 1f;
    private float m_AttackCooltime = 0f;

    // Update is called once per frame
    void Update()
    {
        m_AttackCooltime += Time.deltaTime;
        if (m_AttackCooltime >= m_AttactInterval)
        {
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            var b = bullet.GetComponent<Bullet>();
            b.m_Velocity = transform.forward;

            m_AttackCooltime = 0;

        }

       // GameObject.Find("Player");
       // GameObject.FindGameObjectsWithTag("Player");
       // GameObject.FindObjectOfType<PlayerController>();

        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        if(Player != null)
        {
            Vector3 attacketPoint = Player.transform.position;
            attacketPoint.y = transform.position.y;
            transform.LookAt(Player.transform);
        }
    }
}
