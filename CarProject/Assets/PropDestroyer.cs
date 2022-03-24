using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            Destroy(other.gameObject);
        }
    }
}
