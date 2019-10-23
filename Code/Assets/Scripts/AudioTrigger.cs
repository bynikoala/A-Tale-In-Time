using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    AudioSource audioData;
    public TaleInTimeEvents events;

    private bool flagForUnlock;

    private void Awake()
    {
        audioData = GetComponent<AudioSource>();
        flagForUnlock = false;
    }

    public void PlayAudio()
    {
        if(!audioData.isPlaying) {
            audioData.Play(0);
            flagForUnlock = true;
        }
    }

    private void Update()
    {
        audioData = GetComponent<AudioSource>();
        if (flagForUnlock && !audioData.isPlaying)
        {
            Debug.Log("Events Unlocked by Audio Trigger on " + this.gameObject.name);
            events.UnlockEvents();
            flagForUnlock = false;
        }
    }
}