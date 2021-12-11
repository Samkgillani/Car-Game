using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPositionSet : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.startingPosition = transform;
    }

}
