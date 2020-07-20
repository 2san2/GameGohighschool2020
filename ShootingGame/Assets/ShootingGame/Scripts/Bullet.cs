using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 Movement = transform.up * Speed * Time.deltaTime;
        transform.position += Movement;
    }
}
