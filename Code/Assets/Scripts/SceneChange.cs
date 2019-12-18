﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
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
