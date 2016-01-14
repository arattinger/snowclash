using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float minX;
	public float maxX;
	public float minZ;
	public float maxZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshairImage.width / 2);
//		float yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 2);
		transform.position = Vector3.Lerp(transform.position, new Vector3(
			Mathf.Clamp(Player.playerPos.x, minX, maxX), transform.position.y, 
			Mathf.Clamp(Player.playerPos.z, minZ, maxZ)), 0.1f);

        //transform.position = new Vector3(Player.playerPos.x, transform.position.y, Player.playerPos.z);

    }
}
