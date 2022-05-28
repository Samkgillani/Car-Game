
using System.Collections;
using UnityEngine;

public class Collide : MonoBehaviour
{
    public Material hitMat,tempMat;
    bool canHit=true;
   public static int lifeCount=3;
    public Sprite fadedStar;
    private void Start()
    {
        lifeCount = 3;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            if (canHit)
            {
                canHit = false;
                Invoke(nameof(SetHit),1.5f);
                tempMat = collision.gameObject.GetComponent<MeshRenderer>().material;
                collision.gameObject.GetComponent<MeshRenderer>().material = hitMat;
                lifeCount--;
                UIManager.instance.crashCountTxt.text =(3-lifeCount).ToString();
                UIManager.instance.lifeBars[lifeCount].sprite = fadedStar;
                AudioManager.instance.CrashSound();
                if (lifeCount <= 0)
                { 
                    UIManager.instance.failPanel.SetActive(true);
                    AdsManager.instance?.ShowBanner(GoogleMobileAds.Api.AdSize.MediumRectangle, GoogleMobileAds.Api.AdPosition.TopLeft);
                }
            }
        }
        if (collision.gameObject.CompareTag("Animate"))
        { 
            Time.timeScale = 0;
            UIManager.instance.failPanel.SetActive(true);
        }
    }
    void SetHit()
    {
        canHit = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animate"))
        {
            other.GetComponent<Animator>().enabled = true;
        }
    }
}
