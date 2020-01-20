using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMe : MonoBehaviour
{
    public GameObject wantedPoster;

    public void ActivateObject()
    {
        wantedPoster.SetActive(true);
    }
}
