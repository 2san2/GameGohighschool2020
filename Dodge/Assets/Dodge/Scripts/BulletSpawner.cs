using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_Bullet;
    
    // Update is called once per frame
    void Update()
    { 
        GameObject bullet = GameObject.Instantiate(m_Bullet);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        transform.Rotate(0, 1f, 0);
    }
}
