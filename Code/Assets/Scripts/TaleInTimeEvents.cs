using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TaleInTimeEvents : MonoBehaviour
{
    public Image blackOverlay;
    public float waitTime;

    public RawImage rawImage;
    public VideoPlayer logoVideoPlayer;
    public RawImage fogImage;
    public VideoPlayer fogVideoPlayer;

    private float timer;
    private bool eventLock;
    private int currentOverlayAlpha;
    private int overlayAlphaSave;
    private float fogOverlayAlpha;
    private bool startOverlayBrightening;
    private bool startFog;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = 4.0f;
        timer = 0.0f;
        eventLock = false;
        startOverlayBrightening = false;
        logoVideoPlayer.Prepare();
        fogVideoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward) && !eventLock)
        {
            if (timer >= waitTime)
            {
                Debug.Log("Wait Completed");
                ActivateTarget();
                timer = 0.0f;
                PlayLoadingIcon();
                eventLock = true;
            }
            else
            {
                timer += Time.deltaTime;
                DarkenOverlay();
            }
        }
        else
        {
            timer = 0.0f;
            startOverlayBrightening = true;
        }

        if (startOverlayBrightening && !eventLock)
        {
            overlayAlphaSave = currentOverlayAlpha;
            StartCoroutine("BrightenOverlay");
        }

        if (logoVideoPlayer.isPlaying)
        {
            rawImage.gameObject.SetActive(true);
        }
        else
        {
            rawImage.gameObject.SetActive(false);
        }

        DrawOverlay();
    }

    public void UnlockEvents()
    {
        eventLock = false;
        startOverlayBrightening = true;
    }

    IEnumerator BrightenOverlay()
    {
        for (int i = 0; i < overlayAlphaSave; i++)
        {
            currentOverlayAlpha = currentOverlayAlpha - 1;
            yield return new WaitForSeconds(.1f);
        }

        startOverlayBrightening = false;
    }

    public void DarkenOverlay()
    {
        currentOverlayAlpha = (int) (timer / waitTime * 200);
    }

    public void DrawOverlay()
    {
            blackOverlay.color = new Color32(0, 0, 0, Convert.ToByte(currentOverlayAlpha));
        
    }

    public void PlayLoadingIcon()
    {
        rawImage.texture = logoVideoPlayer.texture;
        logoVideoPlayer.Play();
    }

    public void PlayFog()
    {
        startFog = true;
        fogImage.texture = fogVideoPlayer.texture;
        fogVideoPlayer.Play();
    }

    public void DarkenFog()
    {
        if(fogOverlayAlpha < 255) { fogOverlayAlpha = (int)fogOverlayAlpha + 5; }
        
        fogImage.color = new Color32(0, 0, 0, Convert.ToByte(fogOverlayAlpha));
    }
    public void BrightenFog()
    {
        if (fogOverlayAlpha > 0) { fogOverlayAlpha = (int)fogOverlayAlpha - 5; }
        fogImage.color = new Color32(0, 0, 0, Convert.ToByte(fogOverlayAlpha));
    }

    private void ActivateTarget()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {

            if (hit.collider != null)
            {
                // Find the hit reciver (if existant) and call the method
                var hitReciver = hit.collider.gameObject.GetComponent<AudioTrigger>();
                if (hitReciver != null)
                {
                    hitReciver.PlayAudio();
                }
                // Show the ghost
                var hitReciever2 = hit.collider.gameObject.GetComponent<ActivateMe>();
                if (hitReciever2 != null)
                {
                    hitReciever2.ActivateObject();
                }
            }
        }
    }
}
