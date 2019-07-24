using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoTrigger : MonoBehaviour
{
    public Camera maincam;

    public void PlayVideo()
    {
        var videoPlayer = maincam.GetComponent<UnityEngine.Video.VideoPlayer>();
        if(!videoPlayer.isPlaying)
        {
             videoPlayer.Play();
        }
    }
}