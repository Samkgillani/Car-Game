
using System.Collections;
using UnityEngine;

public class Collide : MonoBehaviour
{
    public Material hitMat,tempMat;
    bool canHit=true;
    int lifeCount=3;
    public Sprite fadedStar;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("ground"))
        {
            if (canHit)
            {
                canHit = false;
                Invoke(nameof(SetHit),1.5f);
                tempMat = collision.gameObject.GetComponent<MeshRenderer>().material;
                collision.gameObject.GetComponent<MeshRenderer>().material = hitMat;
                lifeCount--;
                UIManager.instance.lifeBars[lifeCount].sprite = fadedStar;
                AudioManager.instance.CrashSound();
                if (lifeCount <= 0)
                    UIManager.instance.failPanel.SetActive(true);
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
