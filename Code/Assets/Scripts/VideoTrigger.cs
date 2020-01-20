using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoTrigger : MonoBehaviour
{
    public RawImage targetImage;

    private void Start()
    {
        var videoPlayer = this.gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.Prepare();
    }

    public void PlayVideo()
    {
        var videoPlayer = this.gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();

        if(!videoPlayer.isPlaying)
        {
            targetImage.texture = videoPlayer.texture;
            videoPlayer.Play();
            StartCoroutine("KeepAlphaOn");
        }
    }

    IEnumerator KeepAlphaOn()
    {
        var videoPlayer = this.gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();

        while (videoPlayer.isPlaying)
        {
            targetImage.color = new Color32(0, 0, 0, 255);

            yield return null;
        }

        targetImage.color = new Color32(0, 0, 0, 0);
    }
}