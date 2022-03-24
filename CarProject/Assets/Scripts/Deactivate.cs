using UnityEngine;
using UnityEngine.SceneManagement;

public class Deactivate : MonoBehaviour
{
    public GameObject objToActivate;
    //public float delayTime=1f;
    public void DeactivateNow()
    {
        gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().name.Equals("Garage"))
            objToActivate.SetActive(true);
    }
}
