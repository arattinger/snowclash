using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.playerPos.x, transform.position.y, Player.playerPos.z), 0.5f);
	}
}
