using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GaragePanel : MonoBehaviour
{
    [SerializeField] int[] carCosts;
    [SerializeField] string[] carNames;
    public Text carNameTxt,carCostTxt;
    List<GameObject> cars;
    public Transform carsParent,carsSpecsParent;
    public GameObject buyBtn,watchVideoBtn, selectBtn;
    IEnumerator Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        yield return new WaitForSeconds(0.1f);
        cars = new List<GameObject>();
        foreach (Transform t in carsParent)
        {
            cars.Add(t.gameObject);
        }
        cars[MainMenu.carNum].SetActive(true);
    }

    public void NextCar(string side)
    {
        AudioManager.instance.ButtonClick();
        foreach (GameObject g in cars)
        {
            g.SetActive(false);
        }
        if (side.Equals("right"))
        {
            MainMenu.carNum++;
            if (MainMenu.carNum >= cars.Count)
                MainMenu.carNum = 0;
        }
        else if (side.Equals("left"))
        {
            MainMenu.carNum--;
            if (MainMenu.carNum < 0)
                MainMenu.carNum = cars.Count - 1;
        }
        cars[MainMenu.carNum].SetActive(true);
        SetDetails();
    }
    void SetDetails()
    {
        if (PlayerPrefs.GetInt("car" + MainMenu.carNum) == 1)
        {
            buyBtn.SetActive(false);
            watchVideoBtn.SetActive(false);
            selectBtn.SetActive(true);
        }
        else
        {
            buyBtn.SetActive(true);
            watchVideoBtn.SetActive(true);
            selectBtn.SetActive(false);
        }
        for (int i = 0; i < carsSpecsParent.childCount; i++)
        {
            carsSpecsParent.GetChild(i).gameObject.SetActive(false);
        }
            carsSpecsParent.GetChild(MainMenu.carNum).gameObject.SetActive(true);
        carNameTxt.text = carNames[MainMenu.carNum];
        carCostTxt.text = carCosts[MainMenu.carNum].ToString();
    }
    public void Select()
    {
        PlayerPrefs.SetInt("currentCar",MainMenu.carNum);
        MainMenu.instance.TurnOnPanel(MainMenu.instance.levelSelectionPanel);
    }
    public void BuyCar()
    {
        if (PlayerPrefs.GetInt("cash") > carCosts[MainMenu.carNum])
        {
            MainMenu.instance.cashUpdate(PlayerPrefs.GetInt("cash")-carCosts[MainMenu.carNum]);
            PlayerPrefs.SetInt("car" + MainMenu.carNum, 1);
            buyBtn.SetActive(false);
            watchVideoBtn.SetActive(false);
            selectBtn.SetActive(true);
        }
    }
    private void OnEnable()
    {
        if (MainMenu.instance?.garageCamera != null)
            MainMenu.instance?.garageCamera.SetActive(true);
        Invoke(nameof(SetDetails),0.1f);
    }
    private void OnDisable()
    {
        if(MainMenu.instance?.garageCamera!=null)
        MainMenu.instance?.garageCamera.SetActive(false);
    }
}
