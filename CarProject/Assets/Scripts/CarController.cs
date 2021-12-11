using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform centerOfMass;
    public Transform[] wheelModels;
    public WheelCollider[] wheelColliders;
    [SerializeField] float carSpeed = 200f, currentSpeed,maxSpeed=200f,baseDragForce=0.1f,steeringDragForce=2f, brakeDragForce = 1f, maxSteeringAngle;
    [SerializeField] float downForce, brakeSpeed = 800f;
    PlayerInput input;
    int direction=1;
    Rigidbody playerRigidBody;
    AudioSource playerAudio;
    public float pitchMultiplier, minPitch, maxPitch;

    void Awake()
    {
        input = FindObjectOfType<PlayerInput>();
        playerRigidBody=GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        playerRigidBody.centerOfMass = transform.InverseTransformPoint(centerOfMass.position);
        playerAudio.PlayDelayed(1f);
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = playerRigidBody.velocity.sqrMagnitude;
        ApplySounds();
        ApplyRace();
        ApplySteering();
        ApplyDrag();
        ApplyDownFoce();
        ApplyFrontBrakes();
    }
    void ApplySounds()
    {
        if (input.racePressed)
            playerAudio.pitch += pitchMultiplier*Time.deltaTime;
        else
            playerAudio.pitch -= pitchMultiplier * Time.deltaTime;
        playerAudio.pitch = Mathf.Clamp(playerAudio.pitch,minPitch,maxPitch);
    }
    void ApplyDownFoce()
    {
        playerRigidBody.AddForce(-transform.up*downForce);
    }
    void ApplyFrontBrakes()
    {
        if (input.brakePressed&&input.raceInput>0)
        {
            wheelColliders[2].brakeTorque = brakeSpeed;
            wheelColliders[3].brakeTorque = brakeSpeed;
        }
        else
        { 
            wheelColliders[2].brakeTorque = 0;
            wheelColliders[3].brakeTorque = 0;
        }
    }
    public void ApplyRace()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            if (currentSpeed < maxSpeed)
                wheelColliders[i].motorTorque = carSpeed * input.raceInput * direction;
            else
                wheelColliders[i].motorTorque = 0;
            wheelColliders[i].GetWorldPose(out Vector3 position, out Quaternion rotation);
            wheelModels[i].position = position;
            wheelModels[i].rotation = rotation;
        }
    }
    public void ApplySteering()
    {
        wheelColliders[2].steerAngle= input.steeringInput * maxSteeringAngle;
        wheelColliders[3].steerAngle= input.steeringInput * maxSteeringAngle;
    }    
    public void ApplyDrag()
    {
        if (input.brakePressed)
            baseDragForce = 3;
        else if(input.racePressed)
            baseDragForce = 0.1f;
        else
            baseDragForce = 1.5f;

        playerRigidBody.drag =baseDragForce + (Mathf.Abs(input.steeringInput) * steeringDragForce);
    }
}
