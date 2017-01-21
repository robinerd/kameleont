using System.Collections;
using System.Collections.Generic;
using Assets.Gui.GamesLogic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowMeter : MonoBehaviour
{

    public static float flow = 0; 
    public float flowLimit = 50;
    public float maximumScaleY = 32;

	// Use this for initialization
	void Start () {
        ResetFlow();
	}
	
	// Update is called once per frame
	void Update () {
        flow = Mathf.Clamp(flow, -flowLimit, flowLimit);
        float flowFactor = flow / flowLimit; //From -limit .. limit to -1 .. 1
        transform.localScale = new Vector3(transform.localScale.x, flowFactor * maximumScaleY, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, flowFactor * maximumScaleY / 4, transform.position.z);
    }

    public static void LoseEverything()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void ResetFlow()
    {
        flow = 0;
    }
}
