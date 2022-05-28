using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    public static int carNum,levelNum=40, rewardCounter;
     GameObject currentPanel;
    public GameObject mainMenuPanel,levelSelectionPanel,settingsPanel,quitPanel;
    public GameObject garageCamera;
    public Text cashTxt;
    public Sprite latestLevel;

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
        if(!PlayerPrefs.HasKey("Music"))
            PlayerPrefs.SetInt("Music", 1);
        PlayerPrefs.SetInt("car0",1);
        SettingsPanel.isSound = (PlayerPrefs.GetInt("Sound") == 1);
        SettingsPanel.isMusic = (PlayerPrefs.GetInt("Music") == 1);
        carNum = PlayerPrefs.GetInt("currentCar");
        currentPanel = mainMenuPanel;
        AdsManager.instance?.ShowBanner(GoogleMobileAds.Api.AdSize.Banner,GoogleMobileAds.Api.AdPosition.Top);
        Time.timeScale = 1;
        cashUpdate(PlayerPrefs.GetInt("cash"));
    }
    public void cashUpdate(int currentCash)
    {
        PlayerPrefs.SetInt("cash", currentCash);
        cashTxt.text = currentCash.ToString();
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
    public void RewardedVideoCar()
    {
        rewardCounter = 0;
        AdsManager.instance.ShowRewardedVideo();
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
