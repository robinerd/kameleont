using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingSpinning : Pulsing {

    public float minAngularSpeed = 30;
    public float maxAngularSpeed = 80;
    public Vector3 axis = Vector3.forward;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	protected override void UpdatePulsing(float pulse) {
        pulse = pulse * pulse; //square the sine factor to spend less time at max speed.
        float rotationThisFrame = Time.deltaTime * Mathf.Lerp(minAngularSpeed, maxAngularSpeed, pulse);
        transform.Rotate(axis, rotationThisFrame);
	}
}
