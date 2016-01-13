using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.playerPos.x, transform.position.y, Player.playerPos.z), 0.1f);
        //transform.position = new Vector3(Player.playerPos.x, transform.position.y, Player.playerPos.z);

    }
}
