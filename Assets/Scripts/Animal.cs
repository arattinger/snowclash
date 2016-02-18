using UnityEngine;
using System.Collections;

public class Animal : AnimationUpdate {

    public float moveCooldown = 2f;
    float timer = 0;
    public float dist;
    Vector3 movePosition;

    void Start () {
        movePosition = this.transform.position;
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
    }

	void Update () {
        timer += Time.deltaTime;

        if(timer > moveCooldown)
        {
            float angle = Random.Range(0, 360);
            var x = dist * Mathf.Cos(angle * Mathf.Deg2Rad);
            var y = dist * Mathf.Sin(angle * Mathf.Deg2Rad);
            movePosition = this.transform.position;
            movePosition.x += x;
            movePosition.z += y;
            timer = 0;
            StartCoroutine(ChangeDirection());
            
        }
        UpdateAnimation();
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(0.5f);
        navAgent.SetDestination(movePosition);
    }
}
