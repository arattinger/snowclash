using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
    NavMeshAgent navAgent;
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(Player.playerPos);
        UpdateAnimation();
    }


    void UpdateAnimation()
    {

        if (navAgent.desiredVelocity == Vector3.zero)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (navAgent.desiredVelocity.z > 0.1f)
        {
            animator.SetInteger("Direction", 8);
        }
        else if (navAgent.desiredVelocity.z < -0.1f)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (navAgent.desiredVelocity.x > 0.1f)
        {
            animator.SetInteger("Direction", 6);
        }
        else if (navAgent.desiredVelocity.x < -0.1f)
        {
            animator.SetInteger("Direction", 4);
        }
    }
}
