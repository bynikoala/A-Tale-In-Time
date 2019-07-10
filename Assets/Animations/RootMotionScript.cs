using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]

public class RootMotionScript : MonoBehaviour
{
    public Button AnimationOn;

    void OnAnimatorMove()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("female_move_run_sprint"))
            {
                Vector3 newPosition = transform.position;
                newPosition.z += animator.GetFloat("Runspeed") * Time.deltaTime;
                transform.position = newPosition;
            }
        }

    }

    private void Update()
    {

        Animator animator = GetComponent<Animator>();

        if (transform.localPosition.z > 70)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -11);
            animator.enabled = false;
            

        }

    
    }

    public void OnAnimator()
    {
        Animator animator = GetComponent<Animator>();
        animator.enabled = true;
    }
}
