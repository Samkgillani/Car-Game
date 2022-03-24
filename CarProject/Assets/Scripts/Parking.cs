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
            Invoke("StopCar", 0.3f);
            Invoke("Ending",2f);
        }
    }
    void StopCar()
    {
        GameManager.instance.player.GetComponent<Rigidbody>().isKinematic = true;
    }
    void Ending()
    {
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("levelsCompleted") < MainMenu.levelNum)
            PlayerPrefs.SetInt("levelsCompleted", MainMenu.levelNum);
        Analytics.CustomEvent("LevelComplete" + MainMenu.levelNum);
        UIManager.instance.completePanel.SetActive(true);
        if(MainMenu.levelNum%3==0)
        AdsManager.instance?.ShowInterstitialAd();
    }
}
