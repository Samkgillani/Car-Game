                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        using UnityEngine;
using UnityEngine.Analytics;

public class Parking : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = new Color32(0,255,47,180);
            UIManager.instance.hudPanel.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
            Invoke("StopCar", 0.3f);
            Invoke("Ending",4f);
        }
    }
    void StopCar()
    {
        GameManager.instance.player.GetComponent<Rigidbody>().isKinematic = true;
        GamePlayCamera.instance.FinalSettings();
    }
    void Ending()
    {
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("levelsCompleted") < MainMenu.levelNum)
            PlayerPrefs.SetInt("levelsCompleted", MainMenu.levelNum);
        Analytics.CustomEvent("LevelComplete" + MainMenu.levelNum);
        UIManager.instance.completePanel.SetActive(true);
        AdsManager.instance?.ShowBanner(GoogleMobileAds.Api.AdSize.MediumRectangle, GoogleMobileAds.Api.AdPosition.TopLeft);
        if (MainMenu.levelNum%2==0)
            AdsManager.instance?.ShowInterstitialAd();
    }
}