using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AudioClips",menuName ="ScriptableObjects/AudioClips")]
public class AudioClips : ScriptableObject
{
    public AudioClip mainMenuTheme,gamePlayTheme,buttonClick,crashSound,reverseSound;
}
