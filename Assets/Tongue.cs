using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour {

    public Transform tonguePartPrefab;
    public Transform tongueTarget;
    public int tongueLength = 5;

    Transform tongueTip = null;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < tongueLength; i++)
        {
            AddTonguePart();
        }
    }

	void FixedUpdate () {
        //TODO:
        //Make tongue target move based on co-op input.
		//Apply force on tonguetip towards tongue target.
        //Extend min-distance on spring joint to let the tongue become longer, also based on input.
	}

    void AddTonguePart()
    {
        Transform tonguePart = GameObject.Instantiate(tonguePartPrefab, transform.position, Quaternion.identity, transform);

        if(tongueTip == null)
        {
            tongueTip = transform; //attach first tongue part to this object (Tongue root)
        }

        tonguePart.GetComponent<Joint>().connectedBody = tongueTip.GetComponent<Rigidbody>();
        tongueTip = tonguePart;
    }
}
