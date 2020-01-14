using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    AudioSource[] audioData;
    public Animator[] CharacterAnim;
    public string animationtrigger;
   
    public TaleInTimeEvents events;
    ParticleSystem ps;
    public int audioDelay;

    private bool flagForUnlock;

    private void Awake()
    {
        audioData = GetComponents<AudioSource>();
        flagForUnlock = false;
        ps = GetComponent<ParticleSystem>();
    }

    public void PlayAudio()
    {
        if (!audioData[0].isPlaying) {

            if (CharacterAnim[0])
            {
                for (int i = 0; i <= CharacterAnim.Length-1; i++)
                {
                    CharacterAnim[i].SetBool(animationtrigger, true);                    
                }
            }
            foreach(AudioSource audioClip in audioData) {
                audioClip.PlayDelayed(audioDelay);
            }
        }

        for (int i = 0; i <= CharacterAnim.Length - 1; i++)
        {
            CharacterAnim[i].SetTrigger(animationtrigger);
        }

        if (ps.isEmitting)
        {
            ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        StartCoroutine("CheckForUnlock");
    }

    private void Update()
    {
        audioData = GetComponents<AudioSource>();
        if (flagForUnlock && !audioData[0].isPlaying)
        {
            Debug.Log("Events Unlocked by Audio Trigger on " + this.gameObject.name);
            events.UnlockEvents();
            flagForUnlock = false;
        }
    }

    IEnumerator CheckForUnlock()
    {
        while (audioData[0].isPlaying)
        {
            yield return new WaitForSeconds(.1f);
        }

        flagForUnlock = true;
    }
}