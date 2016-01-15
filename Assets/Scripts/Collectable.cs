using UnityEngine;
using System.Collections;

public enum Collectables
{
    FastMovement,
    Healts,
    StrongerSnowball
}

public class Collectable : MonoBehaviour {

    public Collectables PowerUp;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(PowerUp == Collectables.FastMovement)
            {
                other.GetComponent<Player>().PowerUpMovement();
            }
            else if (PowerUp == Collectables.FastMovement)
            {
                other.GetComponent<Player>().PowerUpHealths();
            }
                Destroy(gameObject);
        }

    }
}
