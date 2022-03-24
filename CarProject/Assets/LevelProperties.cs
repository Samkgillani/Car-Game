using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProperties : MonoBehaviour
{
    public GameObject lockIcon,numText;
    void OnEnable()
    {
        if (transform.GetSiblingIndex() <= PlayerPrefs.GetInt("levelsCompleted"))
        {
            lockIcon.SetActive(false);
            numText.SetActive(true);
            GetComponent<Button>().interactable = true;
            numText.GetComponent<Text>().text = (transform.GetSiblingIndex()+1).ToString();
        }
    }
}
