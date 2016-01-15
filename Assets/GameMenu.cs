using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	// Use this for initialization
	public AudioClip clip;

	void Start () 
	{
		if (clip == null)
			return;

		SoundManager.instance.PlaySingle (clip);
	}
}
