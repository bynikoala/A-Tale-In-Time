using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastVideoTrigger : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider != null)
            {
                // Find the hit reciver (if existant) and call the method
                var hitReciver = hit.collider.gameObject.GetComponent<VideoTrigger>();
                if (hitReciver != null)
                {
                    hitReciver.PlayVideo();
                }
            }
        }
    }
}