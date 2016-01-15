using UnityEngine;
using System.Collections;

public class SinglePlayerScript : MonoBehaviour {

	public void SinglePlayer(int scene)
	{
		SoundManager.instance.efxSource.Stop ();
		Application.LoadLevel (scene);
	}
}
