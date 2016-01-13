using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    NavMeshAgent navAgent;
    public Animator animator;
    public GameObject snowball;
    public Image healthBar;

    float health, maxHealth;

    public static Vector3 playerPos;

    // Use this for initialization
    void Start()
    {
        health = maxHealth = 100f;

        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("tag:" + hit.collider.tag);
                if (hit.collider.tag == "Ground" || hit.collider.tag == "Obstacle")
                {
                    navAgent.SetDestination(hit.point);
                }

                if (hit.collider.tag == "EnemyCollider")
                {
                    GameObject go = (GameObject)Instantiate(snowball, transform.position, Quaternion.identity);
                    go.GetComponent<Snowball>().ActivateSnowball(hit.point, 0f);
                }
            }
        }

        UpdateAnimation();
        playerPos = transform.position;
    }


    void UpdateAnimation()
    {
        //Debug.Log("velocity:" + navAgent.velocity + " desiredVelocity:" + navAgent.desiredVelocity);

        if (navAgent.desiredVelocity == Vector3.zero)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (navAgent.desiredVelocity.z > 0.2f)
        {
            animator.SetInteger("Direction", 8);
        }
        else if (navAgent.desiredVelocity.z < -0.2f)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (navAgent.desiredVelocity.x > 0.2f)
        {
            animator.SetInteger("Direction", 6);
        }
        else if (navAgent.desiredVelocity.x < -0.2f)
        {
            animator.SetInteger("Direction", 4);
        }
    }

    public void DamageAccept(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;

        if (health < 0)
            Destroy(gameObject);
    }
}
