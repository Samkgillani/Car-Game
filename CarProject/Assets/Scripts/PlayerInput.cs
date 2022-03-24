using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float steeringInput, raceInput;
    [SerializeField] float arrowSpeedMultiplier, raceMultiplier;
    public bool racePressed, brakePressed;
    float arrowInput;
    bool isMobile=true;
    private void Start()
    {
#if UNITY_EDITOR
        isMobile = false;
#endif
    }
    private void Update()
    {
        if (!isMobile)
        { 
            raceInput = Input.GetAxisRaw("Vertical");
            steeringInput = Input.GetAxisRaw("Horizontal");
            return;
        }
        if (SettingsPanel.isSteering)
            steeringInput = SimpleInput.GetAxisRaw("Horizontal");
        else
            steeringInput = Mathf.Lerp(steeringInput, arrowInput, arrowSpeedMultiplier);
        if (racePressed)
            raceInput +=raceMultiplier * Time.deltaTime;
        else if (brakePressed)
            raceInput -=raceMultiplier* Time.deltaTime;
        else
            raceInput =0;
        raceInput = Mathf.Clamp(raceInput,-1,1);

    }
    public void GetArrowInput(int direction)
    {
        arrowInput = direction;
    }
    public void GetRaceInput(bool isPressed)
    {
        racePressed = isPressed;
    } 
    public void GetBrakeInput(bool isPressed)
    {
        brakePressed = isPressed;
    }

}
