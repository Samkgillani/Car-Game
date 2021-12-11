using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    public static bool isSound, isSteering;
    public Button steering, arrows, soundOn, soundOff;
    public Sprite selected, notSelected;

    private void Start()
    {
        isSound = (PlayerPrefs.GetInt("Sound") == 1);
        isSteering = (PlayerPrefs.GetInt("Steering") == 1);
        SelectBtn(soundOn.GetComponent<Image>(), soundOff.GetComponent<Image>(), isSound);
        SelectBtn(steering.GetComponent<Image>(), arrows.GetComponent<Image>(), isSteering);
    }
    public void SoundChange(bool _isSound)
    {
        isSound = _isSound;
        PlayerPrefs.SetInt("Sound", isSound ? 1 : 0);
        if (isSound)
            AudioManager.instance.loopAudio1.Play();
        else
            AudioManager.instance.loopAudio1.Stop();
        SelectBtn(soundOn.GetComponent<Image>(), soundOff.GetComponent<Image>(), isSound);
    }
    public void ControlChange(bool _isSteering)
    {
        isSteering = _isSteering;
        PlayerPrefs.SetInt("Steering", isSteering ? 1 : 0);
        SelectBtn(steering.GetComponent<Image>(), arrows.GetComponent<Image>(), isSteering);
    }
    void SelectBtn(Image img1,Image img2, bool isSelected)
    {
        if (isSelected)
        {
            img1.sprite = selected;
            img2.sprite = notSelected;
        }
        else
        {
            img1.sprite = notSelected;
            img2.sprite = selected;
        }
    }
}
