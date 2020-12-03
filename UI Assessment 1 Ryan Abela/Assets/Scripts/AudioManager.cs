using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip music;

    private void Start()
    {
        if(music != null)
        {
            audioSource.clip = music;
            audioSource.Play();
        }
    }
    public void PlaySound(AudioClip currentClip)
    {
       if(currentClip != null)
       {
            audioSource.clip = currentClip;
            audioSource.Play();
       } 
        

    }
}
