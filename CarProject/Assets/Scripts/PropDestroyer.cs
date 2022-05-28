using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier")||other.CompareTag("Obstacle"))
        {
            if(other.transform.parent!=transform)
                Destroy(other.gameObject);
        }
    }
}
