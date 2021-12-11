using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    public static int carNum,levelNum;
     GameObject currentPanel;
    public GameObject mainMenuPanel,levelSelectionPanel,settingsPanel,quitPanel;
    public GameObject garageCamera;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }
    private void Start()
    {
        if(!PlayerPrefs.HasKey("Steering"))
            PlayerPrefs.SetInt("Steering",1);
        if(!PlayerPrefs.HasKey("Sound"))
            PlayerPrefs.SetInt("Sound", 1);
        currentPanel = mainMenuPanel;
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Back();
    }
    public void YesBtn()
    { 
            Application.Quit();
    }
    public void SettingsBtn()
    {
        AudioManager.instance.ButtonClick();
        garageCamera.SetActive(false);
        settingsPanel.SetActive(true);

    }
    public void TurnOnPanel(GameObject panel)
    {
        AudioManager.instance.ButtonClick();
        currentPanel?.SetActive(false);
        currentPanel = panel;
        currentPanel?.SetActive(true);
    }
    public void Back()
    {
        AudioManager.instance.ButtonClick();
        if (settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
            if(mainMenuPanel.activeSelf)
            garageCamera.SetActive(true);
        }
        else if (quitPanel.activeSelf)
        {
            if (mainMenuPanel.activeSelf)
                garageCamera.SetActive(true);
            quitPanel.SetActive(false);
        }
        else if (mainMenuPanel.activeSelf)
        {
            garageCamera.SetActive(false);
            quitPanel.SetActive(true);
        }
        else if(levelSelectionPanel.activeSelf)
        {
            TurnOnPanel(mainMenuPanel);
        }
    }
}
