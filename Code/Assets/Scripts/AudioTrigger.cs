using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    AudioSource audioData;
    public Animator CharacterAnim;
    public TaleInTimeEvents events;
    ParticleSystem ps;

    private bool flagForUnlock;

    private void Awake()
    {
        audioData = GetComponent<AudioSource>();
        flagForUnlock = false;
        ps = GetComponent<ParticleSystem>();
    }

    public void PlayAudio()
    {
        if(!audioData.isPlaying) {
            CharacterAnim.SetBool("startAni1", true);
            audioData.PlayDelayed(0);
            
            flagForUnlock = true;
        }

        if (ps.isEmitting)
        {
            ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
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