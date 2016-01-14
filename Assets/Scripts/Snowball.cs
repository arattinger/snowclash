using UnityEngine;
using System.Collections;

public class Snowball : MonoBehaviour {

    Vector3 target;
    float speed = 1.5f;
    bool isActive = false;
    float damage = 20f;
	Component snowflakes; 
	
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
			Debug.Log ("Position and Transform");
			Debug.Log(Vector3.Angle(transform.position, target));

			// Rotation is updated every time, in case the snowball throw changes to an arc
//			snowflakes.transform.rotation.eulerAngles = v;
//			Vector3 rot = snowflakes.transform.rotation;
//			snowflakes.transform.rotation = Quaternion.Euler();


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
