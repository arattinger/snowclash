using UnityEngine;
using System.Collections;

public class AnimationEvents : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}

    public void ThrowingFinished()
    {
        try
        {
            player.GetComponent<Player>().ThrowingFinished();
        }
        catch (System.Exception) { 
        
            player.GetComponent<Zombie>().ThrowingFinished();
        }  
        
        
    }
}
