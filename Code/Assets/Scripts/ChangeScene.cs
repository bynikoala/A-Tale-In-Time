﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
