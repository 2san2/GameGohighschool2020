using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class itemComponet : MonoBehaviour
{

    public UnityEvent m_BeAteEvent;
        
    public void BeAte()
    {
        m_BeAteEvent.Invoke();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
