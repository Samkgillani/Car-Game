using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelSelection : MonoBehaviour
{
    public GameObject levelSelectionPanel;
    public Button[] levelBtns;
    public GameObject[] locks,nums;
    public void SelectLevel()
    {
        AudioManager.instance.ButtonClick();
        MainMenu.levelNum = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex()+1;
        Analytics.CustomEvent("LevelStart" + MainMenu.levelNum);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
    }
}
