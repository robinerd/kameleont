using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingScale : Pulsing {
    
    public float minScale = 0.5f;
    public float maxScale = 1;

    Vector3 initialScale;

    // Use this for initialization
    void Start () {
        initialScale = transform.localScale;
	}

    protected override void UpdatePulsing(float pulse)
    {
        float scaleFactor = Mathf.Lerp(minScale, maxScale, pulse); //Transform from 0..1 to min..max
        transform.localScale = initialScale * scaleFactor;
    }
}
