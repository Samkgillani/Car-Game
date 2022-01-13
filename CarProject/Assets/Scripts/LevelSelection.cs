using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public GameObject levelSelectionPanel;
    public Button[] levelBtns;
    public GameObject[] locks,nums;
    private void Start()
    {
        for (int i = 0; i < levelBtns.Length; i++)
        {
            locks[i].SetActive(true);
            nums[i].SetActive(false);
            levelBtns[i].interactable = false;
        }
        for (int i = 0; i <= PlayerPrefs.GetInt("levelsCompleted"); i++)
        {
            locks[i].SetActive(false);
            nums[i].SetActive(true);
            levelBtns[i].interactable = true;
        }
    }
    public void SelectLevel(int level)
    {
        AudioManager.instance.ButtonClick();
        MainMenu.levelNum = level-1;
        Analytics.CustomEvent("LevelStart" + MainMenu.levelNum);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
    }
}
