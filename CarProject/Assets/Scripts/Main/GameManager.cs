using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform cars;
    [HideInInspector]public GameObject player;
    GamePlayCamera cam;
    [HideInInspector]public Transform startingPosition;
    public Transform levels;
    Transform checkPoint;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        cam = FindObjectOfType<GamePlayCamera>();
    }

    private void Start()
    {
        AdsManager.instance?.HideBanner();
        UIManager.instance.levelCountTxt.text = (MainMenu.levelNum).ToString();
        //levels.GetChild(MainMenu.levelNum-1).gameObject.SetActive(true);
        player = cars.GetChild(MainMenu.carNum).gameObject;
        player.SetActive(true);
        Invoke(nameof(SetSpawnPosition),0.1f);
        cam.target = cars.GetChild(MainMenu.carNum);
        Time.timeScale = 1;
    }
    public void SetSpawnPosition()
    {
        checkPoint = startingPosition;
        player.transform.position = checkPoint.position;
        player.transform.rotation = checkPoint.rotation;
    }
}
