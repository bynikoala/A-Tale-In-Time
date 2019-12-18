using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class IrrlichtPlayer : MonoBehaviour
{
    private RawImage rawImage;
    private VideoPlayer videPlayer;
    public RawImage irrlicht2;
    public RawImage irrlicht3;

    void Start()
    {
        rawImage = this.gameObject.GetComponent<RawImage>();
        videPlayer = this.gameObject.GetComponent<VideoPlayer>();
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videPlayer.Prepare();
        WaitForSeconds wait = new WaitForSeconds(1);

        while (!videPlayer.isPrepared)
        {
            yield return wait;
            break;
        }

        rawImage.texture = videPlayer.texture;
        irrlicht2.texture = videPlayer.texture;
        irrlicht3.texture = videPlayer.texture;
        videPlayer.Play();
    }
}
