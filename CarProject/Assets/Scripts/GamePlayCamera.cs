
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayCamera : MonoBehaviour
{
    bool isTouch = false;
    public Transform target;
    public float lookSpeed;
    public float currentHeight = 1.5f;
    public float distance = 1.5f;
    public float rotationYAxis = 0.0f, rotationXAxis = 0.0f;
    Quaternion rotation;
    public static GamePlayCamera instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    //void Start()
    //{
    //    Vector3 angles = transform.eulerAngles;
    //    rotationYAxis = angles.y;
    //}
    public static float ClampAngle(float angle)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return angle;
    }

    void FixedUpdate()
    {

        if (target != null)
        {
            rotationXAxis = ClampAngle(rotationXAxis);
            rotation = Quaternion.Euler(rotationXAxis, Mathf.LerpAngle(transform.eulerAngles.y, rotationYAxis + target.eulerAngles.y, lookSpeed * Time.deltaTime), 0);
            Vector3 negDistance = new Vector3(0.0f, currentHeight, -distance);
            Vector3 position = rotation * negDistance + target.position;
            transform.rotation = rotation;
            transform.position = position;
        }
    }
    public void FinalSettings()
    {
        distance = 6;
        currentHeight = 1;
        rotationXAxis = 8;
        GameManager.instance.player.GetComponent<CarProperties>().finalCam.SetActive(true);
        target = GameManager.instance.player.GetComponent<CarProperties>().finalCam.transform;
    }
    public void isTouching(bool _isTouch)
    {
        isTouch = _isTouch;
    }
}