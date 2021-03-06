﻿using System;
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

    public AudioSource soundLick;
    public AudioSource soundEat;

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
                if (!isAttached)
                {
                    soundLick.Play();
                    FlowMeter.flow += flowValue;
                    levelSpawner.EatAndIncreaseSpawnSpeed(flowValue);
                }
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
        if(Vector3.Distance(tongueRoot.transform.position, transform.position) < 1.2f)
        {
            this.enabled = false;
            Score.AddScore(scoreValue);
            //FlowMeter.HasAddedScore(flowValue);
            //instantiate an eat effect prefab here!
            soundEat.Play();
            GameObject.Destroy(gameObject);
        }
	}
}
