using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProperties : MonoBehaviour
{
    public GameObject lockStuff,unlockedStuff, numText;
    void OnEnable()
    {
        if (transform.GetSiblingIndex() <= PlayerPrefs.GetInt("levelsCompleted"))
        {
            lockStuff.SetActive(false);
            unlockedStuff.SetActive(true);
            GetComponent<Button>().interactable = true;
            numText.GetComponent<Text>().text = (transform.GetSiblingIndex()+1).ToString();
        }
        if (transform.GetSiblingIndex() == PlayerPrefs.GetInt("levelsCompleted"))
            GetComponent<Image>().sprite =MainMenu.instance.latestLevel;
    }
}
