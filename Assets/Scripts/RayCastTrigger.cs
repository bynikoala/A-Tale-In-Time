using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTrigger : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider != null)
            {
                // Find the hit reciver (if existant) and call the method
                var hitReciver = hit.collider.gameObject.GetComponent<AudioTrigger>();
                if (hitReciver != null)
                {
                    hitReciver.PlayAudio();
                }
                // Show the ghost
                var hitReciever2 = hit.collider.gameObject.GetComponent<ActivateMe>();
                if(hitReciever2 != null)
                {
                    hitReciever2.ActivateObject();
                }
            }
        }
    }
}