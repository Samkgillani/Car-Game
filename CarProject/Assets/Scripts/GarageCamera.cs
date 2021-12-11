using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    Quaternion rotation;
    public float slowSpeed=0.1f;
    float moveX, moveY;
    float rotationYAxis = 0.0f, rotationXAxis = 0.0f, rotationZAxis = 0.0f;
    bool isTouching=true;
    private void Start()
    {
        rotation = transform.rotation;
    }
    private void Update()
    {
        if (isTouching)
        {
            float pointer_x = Input.GetAxis("Mouse X");
            float pointer_y = Input.GetAxis("Mouse Y");

            if (Input.touchCount > 0)
            {
                pointer_x = Input.touches[0].deltaPosition.x / 4;
                pointer_y = Input.touches[0].deltaPosition.y / 4;
            }
            if (Input.GetMouseButton(0))
            { 
                moveX += pointer_x;
                moveY += pointer_y ;
            }
        }
        rotationYAxis += moveX;
        rotationXAxis -= moveY;
        rotation =Quaternion.Euler(rotationXAxis, rotationYAxis, rotationZAxis);
        transform.position= rotation*offset+target.position;
        transform.LookAt(target);
        moveX = Mathf.Lerp(moveX,0,slowSpeed);
        moveY = Mathf.Lerp(moveY,0,slowSpeed);
    }
    public void SetBool(bool touch)
    {
        isTouching = touch;
    }
}
