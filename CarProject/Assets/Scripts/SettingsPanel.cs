using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    public static bool isSound,isMusic, isSteering;
    public Sprite selected, notSelected,on,off;
    public Image soundImg, musicImg, steeringImg, arrowsImg;
    private void Start()
    {
        isSound = (PlayerPrefs.GetInt("Sound") == 1);
        isMusic = (PlayerPrefs.GetInt("Music") == 1);
        isSteering = (PlayerPrefs.GetInt("Steering") == 1);
        if(isSound)
            soundImg.sprite = on;
        else
            soundImg.sprite = off;
        if(isMusic)
            musicImg.sprite = on;
        else
            musicImg.sprite = off;
        if (isSteering)
        {
            steeringImg.sprite = selected;
            arrowsImg.sprite = notSelected;
        }
        else
        {
            steeringImg.sprite = notSelected;
            arrowsImg.sprite = selected;
        }
    }
    public void SoundChange()
    {
        isSound = !isSound;
        PlayerPrefs.SetInt("Sound", isSound ? 1 : 0);
        if (isSound)
        {
            AudioListener.pause = false;
            soundImg.sprite = on;
        }
        else
        {
            soundImg.sprite = off;
            AudioListener.pause = true;
        }
    }
    public void MusicChange()
    {
        isMusic = !isMusic;
        PlayerPrefs.SetInt("Music", isMusic ? 1 : 0);
        if (isMusic)
        {
            AudioManager.instance.loopAudio1.Play();
            musicImg.sprite = on;
        }
        else
        {
            musicImg.sprite = off;
            AudioManager.instance.loopAudio1.Stop();
        }
    }
    public void ControlChange(bool _isSteering)
    {
        isSteering = _isSteering;
        PlayerPrefs.SetInt("Steering", isSteering ? 1 : 0);
        if (isSteering)
        {
            steeringImg.sprite = selected;
            arrowsImg.sprite = notSelected;
        }
        else
        {
            steeringImg.sprite = notSelected;
            arrowsImg.sprite = selected;
        }
    }

}
