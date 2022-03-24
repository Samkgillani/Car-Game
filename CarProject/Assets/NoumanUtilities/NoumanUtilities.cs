using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoumanUtilities : MonoBehaviour
{
    [ContextMenu("NameSetting")]
    public void NameSetting()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).name = transform.GetChild(i).name + (i + 1);
        }
    }
}
