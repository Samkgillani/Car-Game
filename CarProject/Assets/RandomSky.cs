using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSky : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(Random.Range(0, 1.01f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
