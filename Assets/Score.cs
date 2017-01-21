using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int score = 0;

    public Text scorelabel;

	// Use this for initialization
	void Start () {
        ResetScore();
    }
	
	// Update is called once per frame
	void Update () {
        scorelabel.text = score.ToString();
    }

    public static void AddScore(int scoreValue) {
        float multiplier = GameObject.FindObjectOfType<FlowMeter>().GetMultiplier();
        score += Mathf.RoundToInt(multiplier * scoreValue);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
