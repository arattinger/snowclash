using UnityEngine;
using System.Collections;

public class Snowball : MonoBehaviour {

    Vector3 target;
    float speed = 1.5f;
    bool isActive = false;
    float damage = 20f;
	ParticleSystem particles; 

	void Start() {
		particles = GetComponent<ParticleSystem> ();
	}

    void Update()
    {
        if (isActive)
        {
            Vector3 v = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            v.y = transform.position.y;
            transform.position = v;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("other:" + other.tag);
        if (other.tag == "Enemy")
        {
            other.GetComponent<Zombie>().DamageAccept(damage);
        }

        if (other.tag == "Enemy" || other.tag == "Obstacle")
            Destroy(gameObject);
    }

    public void ActivateSnowball(Vector3 _target, float distance)
    {
        Destroy(gameObject, 1.8f);
        target = _target;
        isActive = true;
    }
}
