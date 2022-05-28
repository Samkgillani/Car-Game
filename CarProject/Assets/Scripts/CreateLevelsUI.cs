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
        int incrementX = 1,incrementY=0;
        for (int i = 0; i < number; i++)
        {
            GameObject temp = Instantiate(obj, obj.transform.parent);
            temp.name = objName + (i+1);
            temp.GetComponent<RectTransform>().anchoredPosition += offsetX * incrementX;
            temp.GetComponent<RectTransform>().anchoredPosition += offsetY * incrementY;
            incrementX++;
            if (incrementX > 6)
            {
                incrementX = 0;
                incrementY++;
            }
        }
    }
}
