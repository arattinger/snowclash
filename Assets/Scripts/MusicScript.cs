using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour {

	public Toggle toggle;

	public void MusicToggle()
	{
		if (!toggle.isOn)
			SoundManager.instance.musicSource.Stop ();
		else
			SoundManager.instance.musicSource.Play ();
	}
}
