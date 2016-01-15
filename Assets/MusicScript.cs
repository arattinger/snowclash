using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour {

	public Toggle toggle;

	public void MusicToggle()
	{
		Debug.Log ("ACTIVE: " + toggle.isOn);
		if (!toggle.isOn)
			SoundManager.instance.efxSource.Stop ();
		else
			SoundManager.instance.efxSource.Play ();
	}
}
