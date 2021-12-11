using System;
using System.Collections;
using System.Collections.Generic;
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
        levels.GetChild(MainMenu.levelNum).gameObject.SetActive(true);
        player = cars.GetChild(MainMenu.carNum).gameObject;
        player.SetActive(true);
        checkPoint = startingPosition;
        SetSpawnPosition();
        cam.target = cars.GetChild(MainMenu.carNum);
        Time.timeScale = 1;
    }
    public void SetSpawnPosition()
    {
        player.transform.position = checkPoint.position;
        player.transform.rotation = checkPoint.rotation;
    }
}
