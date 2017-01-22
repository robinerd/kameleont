using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    public static float BPM = 180;
    public static Music instance;

    public AudioSource baseMusic;
    //Add more channels here later...

	// Use this for initialization
	void Awake () {
        instance = this;
	}
}
