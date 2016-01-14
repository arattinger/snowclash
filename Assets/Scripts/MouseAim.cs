using UnityEngine;
using System.Collections;

public class MouseAim : MonoBehaviour {


	public Texture2D crosshairImage;

	void Start() {
		Cursor.visible = false;
	}
	
	void OnGUI()
	{
		float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshairImage.width / 2);
		float yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
	}
	
}
