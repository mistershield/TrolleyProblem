using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{ 
    public AudioClip normalMusic;
    public AudioClip BadMusic;

    public AudioSource audioSource;

    public void PlayNormalMusic()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(normalMusic);
    }

    public void PlayBadMusic()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(BadMusic);
    }
}
