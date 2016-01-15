using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyBar : MonoBehaviour {
    public static Text text;
    public static int currentEnemies;
    // Use this for initialization
    void Start()
    {
        currentEnemies = 0;
        text = GetComponent<Text>();
        UpdateText();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void EnemiesKnocked()
    {
        currentEnemies++;
        UpdateText();
    }

    public static void UpdateText()
    {
        text.text = currentEnemies.ToString();
    }
}
