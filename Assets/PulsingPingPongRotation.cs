using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingPingPongRotation : Pulsing {
    
    public float minAngle = -15;
    public float maxAngle = 10;
    public Vector3 axis = Vector3.up;

    // Use this for initialization
    void Start () {
		
	}

    protected override void UpdatePulsing(float pulse)
    {
        pulse = pulse * pulse; //square the sine factor to spend less time at max speed.
        float angle = Mathf.Lerp(minAngle, maxAngle, pulse);
        transform.rotation = Quaternion.AngleAxis(angle, axis);
    }
}
