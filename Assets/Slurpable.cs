using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Gui.GamesLogic;
using UnityEngine;

public class Slurpable : MonoBehaviour {

    public float radius = 1.0f;
    public float flowValue; //Set negative flow value for bad stuff.
    public int scoreValue; //Should probably not be negative.

    Tongue tongueRoot;
    Transform attachedToTonguePart = null;
    public Boolean isAttached = false;
    public LevelSpawner levelSpawner;

    // Use this for initialization
    void Start ()
    {
        tongueRoot = GameObject.FindObjectOfType<Tongue>();
        if (tongueRoot == null)
        {
            Debug.LogError("There is no tongue! Disabling slurpability.");
            this.enabled = false;
            return;
        }

        Debug.Assert(flowValue != 0, "Flow value is not initialized!! (in game object: " + gameObject.name + ")");
    }
	
	// Update is called once per frame
	void Update () {

        //Attach to tongue
        for (int i = 0; i < tongueRoot.transform.childCount; i++)
        {
            Transform tonguePart = tongueRoot.transform.GetChild(i);
            if(Vector3.Distance(tonguePart.position, transform.position) < radius)
            {
                isAttached = true;
                attachedToTonguePart = tonguePart;
            }
        }

        //Follow tongue
        if(attachedToTonguePart != null)
        {
            transform.position = Vector3.Lerp(transform.position, attachedToTonguePart.position, 0.5f);
        }

        //Consume
        if(Vector3.Distance(tongueRoot.transform.position, transform.position) < radius * 0.8f)
        {
            FlowMeter.flow += flowValue;
            Score.AddScore(scoreValue);
            this.enabled = false;
            levelSpawner.EatAndIncreaseSpawnSpeed(flowValue);

            //FlowMeter.HasAddedScore(flowValue);
            //instantiate an eat effect prefab here!
            GameObject.Destroy(gameObject);
        }
	}
}
