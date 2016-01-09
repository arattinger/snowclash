using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
    NavMeshAgent navAgent;
    public Animator animator;

	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("tag:" + hit.collider.tag);
                if (hit.collider.tag == "Ground" || hit.collider.tag == "Obstacle")
                {
                    navAgent.SetDestination(hit.point);
                }
            }
        }

        UpdateAnimation();
	}

    void UpdateAnimation()
    {
        if (navAgent.velocity.x == 0)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (navAgent.velocity.z > 0.2f)
        {
            animator.SetInteger("Direction", 8);
        }
        else if (navAgent.velocity.z < -0.2f)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (navAgent.velocity.x > 0.2f)
        {
            animator.SetInteger("Direction", 6);
        }
        else if (navAgent.velocity.x < -0.2f)
        {
            animator.SetInteger("Direction", 4);
        }
    }
}
