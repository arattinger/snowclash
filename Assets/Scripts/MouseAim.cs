using UnityEngine;
using System.Collections;

public class MouseAim : MonoBehaviour {

	private ParticleSystem mouseParticles;
//	public Texture2D crosshairImage;

	void Start() {
		mouseParticles = GetComponent<ParticleSystem> ();
//		Cursor.visible = false;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 pos = new Vector3(Screen.width - (Screen.width - Input.mousePosition.x), Input.mousePosition.y, (Screen.height - Input.mousePosition.z));
			Debug.Log(pos);
			pos = Camera.main.ScreenToWorldPoint(pos);
			pos.y = 1;
			transform.position = pos;
			mouseParticles.Play();
		}
	}

//	void OnGUI()
//	{
//		float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshairImage.width / 2);
//		float yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 2);
//		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
//	}
	
}
