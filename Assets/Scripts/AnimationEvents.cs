using UnityEngine;
using System.Collections;

public class AnimationEvents : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}

    public void ThrowingFinished()
    {
        player.GetComponent<Player>().ThrowingFinished();
    }
}
