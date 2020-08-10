using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBox : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnPointDownEvent()
    {
        GameManager.Instance.DamageLife();
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1, 0) * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane")
        {
            Destroy(gameObject);
            GameManager.Instance.AddScore();
        }
    }
}
