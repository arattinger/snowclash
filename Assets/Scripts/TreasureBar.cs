using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TreasureBar : MonoBehaviour {
    public static Text text;
    public static int maxTreasures, currentTreasures;
	// Use this for initialization
	void Start () {
        maxTreasures = 5;
        currentTreasures = 0;
        text = GetComponent<Text>();
        UpdateText();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void TreasureCollected()
    {
        currentTreasures++;
        UpdateText();
    }

    public static void UpdateText()
    {
        text.text = currentTreasures + "/" + maxTreasures;
    }
}
