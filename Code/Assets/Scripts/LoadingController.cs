using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingController : MonoBehaviour
{
    public GameObject loadingScreenObject;
    public Slider slider;

    public VideoPlayer loadingPlayer;
    public RawImage loadingImage;

    private AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        loadingImage.color = new Color32(0, 0, 0, 255);
        loadingImage.texture = loadingPlayer.texture;
        StartCoroutine("LoadingScreen");
    }

    IEnumerator LoadingScreen()
    {
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if(async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
