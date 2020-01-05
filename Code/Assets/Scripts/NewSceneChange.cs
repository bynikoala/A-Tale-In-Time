using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class NewSceneChange : MonoBehaviour
{
    public GameObject pastScene;
    public GameObject futureScene;

    public TaleInTimeEvents eventsystem;
    private void OnTriggerEnter(Collider other)
    {
        eventsystem.PlayFog();

        if (futureScene.activeSelf)
        {
            pastScene.SetActive(true);
            futureScene.SetActive(false);
        }
        else if (pastScene.activeSelf)
        {
            futureScene.SetActive(true);
            pastScene.SetActive(false);
        }
    }
}