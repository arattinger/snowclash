using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
    NavMeshAgent navComponent;

	// Use this for initialization
	void Start () {
        navComponent = GetComponent<NavMeshAgent>();
        navComponent.updateRotation = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                navComponent.SetDestination(hit.point);
            }
            
        }
        
	}
}
