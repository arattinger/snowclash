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
    public float shotCooldown = 1.0f;
    float timer = 0;

    float health, maxHealth;
    float damage = 0.2f;


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
        Debug.Log(navAgent.remainingDistance);
        navAgent.SetDestination(Player.playerPos);
        UpdateAnimation();

        timer += Time.deltaTime;
        // If we reached a certain distance we can throw the ball!
        if (throwRange + 0.05 > navAgent.remainingDistance && timer > shotCooldown) {
            GameObject go = (GameObject)Instantiate(snowball, transform.position, snowball.transform.rotation);
            go.GetComponent<Snowball>().ActivateSnowball(Player.playerPos, 0f, Snowball.hitTarget.Player);
            timer = 0;
        }

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
