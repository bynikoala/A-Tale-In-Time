using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    AudioSource audioData;
    public Animator[] CharacterAnim;
    public string animationtrigger;
   
    public TaleInTimeEvents events;
    ParticleSystem ps;
    public int audioDelay;

    private bool flagForUnlock;

    private void Awake()
    {
        audioData = GetComponent<AudioSource>();
        flagForUnlock = false;
        ps = GetComponent<ParticleSystem>();
    }

    public void PlayAudio()
    {
        if (!audioData.isPlaying) {

            if (CharacterAnim[0])
            {
                for (int i = 0; i <= CharacterAnim.Length-1; i++)
                {
                    CharacterAnim[i].SetBool(animationtrigger, true);                    
                }
            }
            audioData.PlayDelayed(audioDelay);

            flagForUnlock = true;
        }

        for (int i = 0; i <= CharacterAnim.Length - 1; i++)
        {
            CharacterAnim[i].SetTrigger(animationtrigger);
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