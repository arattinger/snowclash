using UnityEngine;
using System.Collections;

public class Animal : AnimationUpdate
{

    public float moveCooldown = 2f;
    float timer = 0;
    public float dist;
    Vector3 movePosition;
    public GameObject animal;
    public AudioClip chickenHit;

    int chickenCounter = 0;
    float damage = 5f;
    public float spawnDistance;
    enum mode { Walking, Attacking };
    mode currentMode = mode.Walking;
    Vector3 flyingStart;
    public float speed = 2;
    bool reachedPlayer = false;
    int hitCount = 0;

    void Start()
    {
        movePosition = this.transform.position;
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
    }

    void Update()
    {
        if (currentMode == mode.Walking)
        {
            timer += Time.deltaTime;

            if (timer > moveCooldown)
            {
                movePosition = calculatePositionFromRandomAngle(this.transform.position);
                timer = 0;
                StartCoroutine(ChangeDirection());

            }
        }
        else if (currentMode == mode.Attacking)
        {
            float step = speed * Time.deltaTime;
            if (reachedPlayer)
            {
                transform.position = Vector3.MoveTowards(transform.position, flyingStart, step);
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, Player.playerPos, step);
                //Debug.Log(Vector3.Distance(transform.position, Player.playerPos));
                if (Vector3.Distance(transform.position, Player.playerPos) < 0.05)
                {
                    reachedPlayer = true;
                }
            }
        }
        UpdateAnimation();
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(0.5f);
        navAgent.SetDestination(movePosition);
    }

    public void DamageAccept(float damage)
    {
        SoundManager.instance.PlaySingle(chickenHit);
        hitCount++;
        if(hitCount == 3) {
            chickenCounter = 0;
            StartCoroutine(SpawnFlyingChicken());
            hitCount = 0;
        }
    }

    Vector3 calculatePositionFromRandomAngle(Vector3 position)
    {
        float angle = Random.Range(0, 360);
        return calculatePositionFromAngle(position, spawnDistance, angle);
    }

    Vector3 calculatePositionFromAngle(Vector3 position, float spawnDistance, float angle)
    {
        var x = spawnDistance * Mathf.Cos(angle * Mathf.Deg2Rad);
        var y = spawnDistance * Mathf.Sin(angle * Mathf.Deg2Rad);
        Vector3 movePosition = position;
        movePosition.x += x;
        movePosition.y = 0;
        movePosition.z += y;
        return movePosition;
    }

    IEnumerator SpawnFlyingChicken()
    {
        yield return new WaitForSeconds(0.25f);
        if (chickenCounter < 20)
        {
            float angle = Random.Range(0, 360);
            movePosition = calculatePositionFromAngle(Player.playerPos, spawnDistance, angle);

            GameObject go = (GameObject)Instantiate(animal, movePosition, animal.transform.rotation);
            go.GetComponent<Animal>().currentMode = mode.Attacking;
            go.GetComponent<Animal>().flyingStart = movePosition;
            //go.GetComponent<BoxCollider>().enabled = false;
            go.GetComponent<NavMeshAgent>().enabled = false;

            chickenCounter++;
            StartCoroutine(DestroyAnimal(go));
            StartCoroutine(SpawnFlyingChicken());
        }
    }

    IEnumerator DestroyAnimal(GameObject go)
    {
        yield return new WaitForSeconds(5f);
        Destroy(go);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //SoundManager.instance.PlaySingle(snowballHit);
            other.GetComponent<Player>().DamageAccept(damage);
        }
    }
}
