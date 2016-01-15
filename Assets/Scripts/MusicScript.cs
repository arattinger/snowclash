using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour {

	public Toggle toggle;
	public AudioClip clip;

	void Start () 
	{
		if (clip == null)
			return;

		SoundManager.instance.PlaySingle (clip);
	}

	public void MusicToggle()
	{
		if (!toggle.isOn)
			SoundManager.instance.efxSource.Stop ();
		else
			SoundManager.instance.efxSource.Play ();
	}
}
