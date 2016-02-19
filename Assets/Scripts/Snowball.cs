using UnityEngine;
using System.Collections;

public class Snowball : MonoBehaviour {

    Vector3 target;
    float speed = 1.5f;
    bool isActive = false;
    float damage = 20f;
	Component snowflakes;
	public AudioClip snowballHit;	
    public enum hitTarget { Player, Enemy, Animal };

    // Determines if the snowball is thrown at the player or the enemy
    // This is used to prevent: Friendly Fire, and Enemies killing themself
    hitTarget aimedAt;

	void Start() {
//		Component[] children;
//		children = GetComponentsInChildren <Component>();
//		foreach (Component child in children) {
//			if(child.tag == "Snowflakes") {
//				snowflakes = child;
//			}
//		}
	}

    void Update()
    {
        if (isActive)
        {
            Vector3 v = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

//			Debug.Log("First");
//			Debug.Log(v);
            v.y = transform.position.y;
            transform.position = v;
			//Debug.Log ("Position and Transform");
			//Debug.Log(Vector3.Angle(transform.position, target));

			// Rotation is updated every time, in case the snowball throw changes to an arc
//			snowflakes.transform.rotation.eulerAngles = v;
//			Vector3 rot = snowflakes.transform.rotation;
//			snowflakes.transform.rotation = Quaternion.Euler();


        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("other:" + other.tag);
        if (other.tag == "Enemy" && aimedAt == hitTarget.Enemy)
        {	
			SoundManager.instance.PlaySingle (snowballHit);
            other.GetComponent<Zombie>().DamageAccept(damage);
        }

        if (other.tag == "Player" && aimedAt == hitTarget.Player)
        {
            SoundManager.instance.PlaySingle(snowballHit);
            other.GetComponent<Player>().DamageAccept(damage);
        }

        if(other.tag == "Animal")
        {
            //Debug.Log("hit the chicken");
            other.GetComponent<Animal>().DamageAccept(damage);
        }

        // TODO: This all needs to be changed to the thrower
        // The initial idea behind this was that the snowball can't
        // instantially destroy itself when thrown by the enemy
        if ((other.tag == "Enemy" && aimedAt == hitTarget.Enemy) ||
            (other.tag == "Player" && aimedAt == hitTarget.Player) ||
            other.tag == "Animal" ||
            other.tag == "Obstacle")
            Destroy(gameObject);
    }

    public void ActivateSnowball(Vector3 _target, float distance, hitTarget aimedAt)
    {
        Destroy(gameObject, 1.5f);
        target = _target;
        isActive = true;
        this.aimedAt = aimedAt;
    }
}
