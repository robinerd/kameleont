using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public static int score = 0;

	// Use this for initialization
	void Start () {
        ResetScore();
    }
	
	// Update is called once per frame
	void Update () {
		
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
