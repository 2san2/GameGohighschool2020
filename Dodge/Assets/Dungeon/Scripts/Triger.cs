using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Triger : MonoBehaviour
{
    public UnityEvent m_OnEnter;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("중원이");
           if( other.attachedRigidbody != null)
            {
                var player = other.attachedRigidbody.GetComponent<PlayerController_Dungeon>();
                if (player != null)
                    //player.Die();
                m_OnEnter.Invoke();
            }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("엄마");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("아빠");
    }


}
