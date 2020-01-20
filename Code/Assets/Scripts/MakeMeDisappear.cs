using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMeDisappear : MonoBehaviour
{
    private float time;

    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            time += Time.deltaTime;

            if (time >= 50)
            {
                this.gameObject.SetActive(false);
            }
        }
        else { time = 0; }
    }
}
