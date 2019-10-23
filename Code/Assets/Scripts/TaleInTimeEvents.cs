using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaleInTimeEvents : MonoBehaviour
{
    public Image loadIcon;
    public float waitTime;

    private float timer;
    private bool eventLock;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = 4.0f;
        timer = 0.0f;
        eventLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward) && !eventLock)
        {
            if (timer >= waitTime)
            {
                Debug.Log("Wait Completed");
                ActivateTarget();
                timer = 0.0f;
                //Animation for successful activation
                eventLock = true;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            timer = 0.0f;
        }


        DrawLoadingIcon();
    }

    public void UnlockEvents()
    {
        eventLock = false;
    }

    public void DrawLoadingIcon()
    {
        loadIcon.fillAmount = timer / waitTime;
    }

    private void ActivateTarget()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
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
                if (hitReciever2 != null)
                {
                    hitReciever2.ActivateObject();
                }
            }
        }
    }
}
