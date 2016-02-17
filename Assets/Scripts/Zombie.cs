using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Zombie : MonoBehaviour {
    NavMeshAgent navAgent;
    public Animator animator;
    public Image healthBar;
    public float throwRange = 0.85f;
    public GameObject snowball;

    // shotCooldown and timer are used to limit the intervals
    // the enemy can shoot in. timer has to be 0!
    public float shotCooldown = 2f;
    float timer = 0;

    float health, maxHealth;
    float damage = 0.2f;
    bool isThrowing = false;


    // Use this for initialization
    void Start()
    {
        health = maxHealth = 100f;

        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
        navAgent.stoppingDistance = throwRange;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Magnitude(this.transform.position - Player.playerPos));
        //Debug.Log(navAgent.remainingDistance);
        navAgent.SetDestination(Player.playerPos);
        
        timer += Time.deltaTime;
        // If we reached a certain distance we can throw the ball!
        if ((throwRange + 0.05 > navAgent.remainingDistance && timer > shotCooldown) || isThrowing) {
            UpdateAnimationShooting();
            timer = 0;
        } else
        {
            UpdateAnimation();
        }

    }

    public void ThrowingFinished()
    {
        if(isThrowing)
        {
            isThrowing = false;
            GameObject go = (GameObject)Instantiate(snowball, transform.position, snowball.transform.rotation);
            go.GetComponent<Snowball>().ActivateSnowball(Player.playerPos, 0f, Snowball.hitTarget.Player);
            Debug.Log("Throwing Finished");
        }
    }

    void UpdateAnimation()
    {
        animator.SetFloat("Throw", 0.0f);
        float horizontal = navAgent.desiredVelocity.normalized.x;
        float vertical = navAgent.desiredVelocity.normalized.z;
     
        if(Mathf.Abs(vertical) > Mathf.Abs(horizontal))
        {
            horizontal = 0;
        } else
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

    void UpdateAnimationShooting()
    {
        isThrowing = true;
        animator.SetFloat("Throw", 1.0f);
        animator.SetFloat("Speed", 0.0f);
    }

    public void DamageAccept(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;

        if (health < 0)
        {
            EnemyBar.EnemiesKnocked();
            Destroy(gameObject);
        }
    }



    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<Player>().DamageAccept(damage);
    }
}
