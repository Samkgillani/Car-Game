using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    public Vector3 rotateVector;

    void Update()
    {
        transform.Rotate(rotateVector);
    }
}
