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

    private float timer;
    private bool eventLock;
    private float currentOverlayAlpha;
    private bool startOverlayBrightening;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = 4.0f;
        timer = 0.0f;
        eventLock = false;
        startOverlayBrightening = false;
        logoVideoPlayer.Prepare();
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
        }

        if (startOverlayBrightening)
        {
            BrightenOverlay();
        }

        DrawOverlay();
    }

    public void UnlockEvents()
    {
        eventLock = false;
        startOverlayBrightening = true;
    }

    public void BrightenOverlay()
    {
        if (currentOverlayAlpha > 0)
        {
            currentOverlayAlpha = (int)currentOverlayAlpha - 2;
            return;
        }
        else
        {
            startOverlayBrightening = false;
        }
    }

    public void DarkenOverlay()
    {
        currentOverlayAlpha = timer / waitTime * 200;
    }

    public void DrawOverlay()
    {
        if (eventLock)
        {
            blackOverlay.color = new Color32(0, 0, 0, 200);
        }
        else
        {
            blackOverlay.color = new Color32(0, 0, 0, Convert.ToByte(currentOverlayAlpha));
        }
    }
    public void PlayLoadingIcon()
    {
        rawImage.texture = logoVideoPlayer.texture;
        logoVideoPlayer.Play();
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
