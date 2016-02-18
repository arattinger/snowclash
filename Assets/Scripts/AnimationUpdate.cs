using UnityEngine;
using System.Collections;

public class AnimationUpdate : MonoBehaviour {
    public NavMeshAgent navAgent;
    public Animator animator;

    public void UpdateAnimation()
    {
        animator.SetFloat("Throw", 0.0f);
        float horizontal = navAgent.desiredVelocity.normalized.x;
        float vertical = navAgent.desiredVelocity.normalized.z;

        if (Mathf.Abs(vertical) > Mathf.Abs(horizontal))
        {
            horizontal = 0;
        }
        else
        {
            vertical = 0;
        }

        //Debug.Log("horizonal: " + horizontal + " vertical: " + vertical);

        //Debug.Log(vertical + " && " + horizontal);
        //Debug.Log(Vector3.Angle(new Vector3(0, navAgent.desiredVelocity.y, 0), navAgent.desiredVelocity));

        if (vertical > 0)
        {
            //Debug.Log("Up");
            animator.SetInteger("Direction", 2);
            animator.SetFloat("Speed", 1f);
        }
        else if (vertical < 0)
        {
            //Debug.Log("Down");
            animator.SetInteger("Direction", 0);
            animator.SetFloat("Speed", 1f);
        }
        else if (horizontal < 0)
        {
            //Debug.Log("Left");
            animator.SetInteger("Direction", 1);
            animator.SetFloat("Speed", 1f);
        }
        else if (horizontal > 0)
        {
            //Debug.Log("Right");
            animator.SetInteger("Direction", 3);
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }
    }
}
