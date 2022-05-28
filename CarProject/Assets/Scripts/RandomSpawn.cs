using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] objs;
    private void Start()
    {
            Instantiate(objs[Random.Range(0,objs.Length)], transform.position, transform.rotation, transform);
    }
}
