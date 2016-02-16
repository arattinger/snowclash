using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    int count = 0;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(AddEnemy());
    }

    IEnumerator AddEnemy()
    {
        GameObject go = (GameObject)Instantiate(enemy, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        count++;
        if(count < 1)
            StartCoroutine(AddEnemy());
    }
}