using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            loopAudio1.clip = audioClips.mainMenuTheme;
        if (PlayerPrefs.GetInt("Sound") == 1)
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
