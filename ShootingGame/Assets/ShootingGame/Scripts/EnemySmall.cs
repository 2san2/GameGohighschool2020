using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : MonoBehaviour
{
    public float Speed;
    public Bullet bullet;
    float CreateTime;
    public bool isDead;
    
    void Update()
    {
        CreateTime += Time.deltaTime;
        transform.position -= Vector3.up * Speed * Time.deltaTime;
        if (CreateTime > 0.4)
        {
           var Enemybullet = GameObject.Instantiate(bullet);
          Enemybullet.transform.position = transform.position;
          Enemybullet.transform.rotation = transform.rotation;
    
          Enemybullet.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 180);
          Enemybullet.transform.position = transform.position + new Vector3(0, -1, 0);
            CreateTime = 0;
        }
       
    }
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddScore();
        animator.SetBool("Die", true);
        //isDead = true;
    }
    

    public void Die()
    {
        Destroy(gameObject);
    }
}
