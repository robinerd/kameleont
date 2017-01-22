using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingGround : Pulsing {

    public float minGrid = 0.9f;
    public float maxGrid = 0.9f;
    public float min1 = 0.0f;
    public float max1 = 1.0f;
    public float min2 = 0.0f;
    public float max2 = 1.0f;

    Material material;

	// Use this for initialization
	void Start () {
        material = GetComponent<MeshRenderer>().material;
        material.SetFloat("_Blend", 1.0f);
    }

    // Update is called once per frame
    protected override void UpdatePulsing(float pulse)
    {
        material.SetFloat("_Square1", Mathf.Lerp(min1, max1, pulse));
        material.SetFloat("_Square2", Mathf.Lerp(max2, min2, pulse)); //Inverted order
        material.SetFloat("_Grid", Mathf.Lerp(min1, max1, pulse));
    }
}
