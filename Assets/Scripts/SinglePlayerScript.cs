using UnityEngine;
using System.Collections;

public class SinglePlayerScript : MonoBehaviour {

	public void SinglePlayer(int scene)
	{
		SoundManager.instance.musicSource.Stop ();
		Application.LoadLevel (scene);
	}
}
