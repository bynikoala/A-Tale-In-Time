using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public TaleInTimeEvents eventsystem;
    private void OnTriggerEnter(Collider other)
    {
        eventsystem.PlayFog();

        if(SceneManager.GetActiveScene().name == "PrototypePastScene")
        {
            SceneManager.LoadScene("PrototypeFutureScene", LoadSceneMode.Single);
        }
        else if(SceneManager.GetActiveScene().name == "PrototypeFutureScene")
        {
            SceneManager.LoadScene("PrototypePastScene",LoadSceneMode.Single);
        }
    }
}
