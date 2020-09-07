using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetctSpawner : MonoBehaviour
{
    public GameObject m_EffectPrefab;

    // Update is called once per frame
    public void SpawnEffect()
    {
        GameObject.Instantiate(m_EffectPrefab, transform.position, transform.rotation);
    }
}
