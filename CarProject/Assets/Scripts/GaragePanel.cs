using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GaragePanel : MonoBehaviour
{
    [SerializeField]float[] accelerationAmount, handlingAmount, brakeAmount;
    [SerializeField] string[] carNames;
    public Text carName;
    public Image accelerationImg, handlingImg, brakeImg;
    List<GameObject> cars;
    public Transform carsParent;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        cars = new List<GameObject>();
        foreach (Transform t in carsParent)
        {
            cars.Add(t.gameObject);
        }
        cars[MainMenu.carNum].SetActive(true);
        SetDetails();
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
        accelerationImg.fillAmount = accelerationAmount[MainMenu.carNum];
        handlingImg.fillAmount = handlingAmount[MainMenu.carNum];
        brakeImg.fillAmount = brakeAmount[MainMenu.carNum];
        carName.text = carNames[MainMenu.carNum];
    }
    public void Select()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnEnable()
    {
        if (MainMenu.instance?.garageCamera != null)
            MainMenu.instance?.garageCamera.SetActive(true);
    }  
    private void OnDisable()
    {
        if(MainMenu.instance?.garageCamera!=null)
        MainMenu.instance?.garageCamera.SetActive(false);
    }
}
