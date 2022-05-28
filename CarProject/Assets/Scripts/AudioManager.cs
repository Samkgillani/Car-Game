using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource loopAudio1, loopAudio2, oneTimeAudio;

    public AudioClips audioClips;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex==1)
            loopAudio1.clip = audioClips.mainMenuTheme;
        else
            loopAudio1.clip = audioClips.gamePlayTheme;
        if (PlayerPrefs.GetInt("Sound")==1)
        {
            AudioListener.pause = false;
        }
        if (PlayerPrefs.GetInt("Music") == 1)
        { 
            loopAudio1.Play();
        }
    }
    public void ButtonClick()
    {
        oneTimeAudio.clip = audioClips.buttonClick;
        oneTimeAudio.Play();
    }
    public void PlayReverseSound(bool play)
    {
        loopAudio2.clip = audioClips.reverseSound;
        if (play)
            loopAudio2.Play();
        else
            loopAudio2.Stop();
    }
    public void CrashSound()
    {
        oneTimeAudio.clip = audioClips.crashSound;
        oneTimeAudio.Play();
    }
}
