using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevelsUI : MonoBehaviour
{
    public int number;
    public string objName;
    public Vector2 offsetX,offsetY;
    public GameObject obj;
    [ContextMenu("MakeUI")]
    public void MakeUI()
    {
        int incrementX = 1;
        for (int i = 0; i < number; i++)
        {
            GameObject temp = Instantiate(obj, obj.transform.parent);
            temp.name = objName + (i+1);
            if (i % 2 == 0)
            {
                temp.GetComponent<RectTransform>().anchoredPosition += offsetY;
                if (i != 0)
                { 
                temp.GetComponent<RectTransform>().anchoredPosition += offsetX * incrementX;
                incrementX++;
                }
            }
            else
            {
                temp.GetComponent<RectTransform>().anchoredPosition += offsetX * incrementX;
            }
        }
    }
}
