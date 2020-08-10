using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour//, IPointerDownHandler
{

    /*private void OnMouseDown()
    {
        Debug.Log("오브젝트 눌름");
    }*/
    public void OnPointerDownEvent(BaseEventData eventData)
    {
        Destroy(gameObject);
    }

}
