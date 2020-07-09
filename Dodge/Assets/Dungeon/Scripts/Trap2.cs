using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Trap2 : MonoBehaviour
{
    public UnityEvent m_OnExit;


    private void OnCollisionStay(Collision collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            var player = collision.rigidbody.GetComponent<PlayerController_Dungeon>();
            if (player != null)
                //player.Die();
                m_OnExit.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}