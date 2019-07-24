using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMe : MonoBehaviour
{
    public GameObject littleGhost;

    public void ActivateObject()
    {
        littleGhost.SetActive(true);
    }
}
