using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator BlackHong;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            BlackHong.SetTrigger("Die");
        }
    }
}
