using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator san;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            san.SetTrigger("Attack");
        }
    }
}
