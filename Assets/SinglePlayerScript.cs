using UnityEngine;
using System.Collections;

public class SinglePlayerScript : MonoBehaviour {

	public void SinglePlayer(int scene)
	{
		Application.LoadLevel (scene);
	}
}
