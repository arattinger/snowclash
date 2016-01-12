using UnityEngine;
using System.Collections;

public class Snowball : MonoBehaviour {

    Vector3 target;
    float speed = 1.5f;
    bool isActive = false;

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
            Destroy(other.gameObject);
        }

        if (other.tag == "Enemy" || other.tag == "Obstacle")
            Destroy(gameObject);
    }

    public void ActivateSnowball(Vector3 _target, float distance)
    {
        Destroy(gameObject, 2.5f);
        target = _target;
        isActive = true;
    }
}
