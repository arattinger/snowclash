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
    Vector3 throwingPosition;
    bool isAttacking = false;

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
        playerPos = transform.position;

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

                    navAgent.Resume();
                    isAttacking = false;
                }

                if ((hit.collider.tag == "EnemyCollider") && !isAttacking)
                {
                    throwingPosition = hit.point;
                    
                    navAgent.Stop();
                    isAttacking = true;

                    //Time.timeScale = 0.5f;

                    UpdateAnimationShooting(throwingPosition);

                }
            }
        }

        if(!isAttacking)
            UpdateAnimation();

    }


    void UpdateAnimation()
    {
        if (navAgent.desiredVelocity == Vector3.zero)
        {
            if(animator.GetInteger("Direction") == 8)
                animator.SetInteger("Direction", -8);
            else if (animator.GetInteger("Direction") == 2)
                animator.SetInteger("Direction", -2);
            else if (animator.GetInteger("Direction") == 6)
                animator.SetInteger("Direction", -6);
            else if (animator.GetInteger("Direction") == 4)
                animator.SetInteger("Direction", -4);
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

    void UpdateAnimationShooting(Vector3 hit)
    {
        float angle = Mathf.Atan2(hit.z - transform.position.z, hit.x - transform.position.x) * Mathf.Rad2Deg;
        if (angle < 0)
            angle = 360 + angle;

        if (angle > 45 && angle < 135)
            animator.SetInteger("Direction", 88);
        else if (angle >= 135 && angle < 225)
            animator.SetInteger("Direction", 44);
        else if (angle >= 225 && angle < 315)
            animator.SetInteger("Direction", 22);
        else
            animator.SetInteger("Direction", 66);
    }

    public void DamageAccept(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;

        if (health < 0)
            Destroy(gameObject);
    }

    public void ThrowingFinished()
    {
        isAttacking = false;

        if (animator.GetInteger("Direction") == 88)
            animator.SetInteger("Direction", -8);
        else if (animator.GetInteger("Direction") == 22)
            animator.SetInteger("Direction", -2);
        else if (animator.GetInteger("Direction") == 66)
            animator.SetInteger("Direction", -6);
        else if (animator.GetInteger("Direction") == 44)
            animator.SetInteger("Direction", -4);

        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
        GameObject go = (GameObject)Instantiate(snowball, pos, snowball.transform.rotation);
        go.GetComponent<Snowball>().ActivateSnowball(throwingPosition, 0f);

        /*if (animator.GetInteger("Direction") == -2) {
            Vector3 childPos = go.transform.GetChild(0).transform.position;
            childPos.y = -0.5f;
            go.transform.GetChild(0).transform.position = childPos;
        }*/
    }
}
