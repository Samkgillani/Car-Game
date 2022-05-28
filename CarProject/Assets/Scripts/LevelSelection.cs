using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelSelection : MonoBehaviour
{
    public GameObject levelSelectionPanel;
    private void OnEnable()
    {
        SnapTo(contentPanel.GetChild(PlayerPrefs.GetInt("levelsCompleted")).GetComponent<RectTransform>());
    }
    public void SelectLevel()
    {
        AudioManager.instance.ButtonClick();
        MainMenu.levelNum = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex()+1;
        Analytics.CustomEvent("LevelStart" + MainMenu.levelNum);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
    }
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] RectTransform contentPanel;
    public Vector2 offset;
    public void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();
        Vector2 viewportLocalPosition = scrollRect.viewport.localPosition;
        Vector2 childLocalPosition = target.localPosition;
        Vector2 result = new Vector2(
            0 - (viewportLocalPosition.x + childLocalPosition.x),
            0 - (viewportLocalPosition.y + childLocalPosition.y)
        );
        scrollRect.content.localPosition = result+ offset;
    }
}
