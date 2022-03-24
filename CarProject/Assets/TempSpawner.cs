using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSpawner : MonoBehaviour
{
    public GameObject prop;
    [ContextMenu("Spawn")]
    public void Spawn()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Instantiate(prop, transform.GetChild(i).position, transform.GetChild(i).rotation, transform.GetChild(i));
        }
    }
    [ContextMenu("Destroy")]
    public void Destroy()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(i).GetChild(0).gameObject);
        }
    }
}
