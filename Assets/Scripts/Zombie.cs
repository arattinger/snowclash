using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
    public Transform victim;
    NavMeshAgent navComponent;

	// Use this for initialization
	void Start () {
        navComponent = GetComponent<NavMeshAgent>();

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
