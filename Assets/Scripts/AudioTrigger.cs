using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    AudioSource audioData;

    public void PlayAudio()
    {
        audioData = GetComponent<AudioSource>();
        if(!audioData.isPlaying) {
            audioData.Play(0);
        }
    }
}