using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingStone : Pulsing
{

    public float minGrid = 0.9f;
    public float maxGrid = 0.9f;
    public float min = 0.0f;
    public float max = 1.0f;

    Material material;

    // Use this for initialization
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        material.SetFloat("_Blend", 1.0f);
    }

    // Update is called once per frame
    protected override void UpdatePulsing(float pulse)
    {
        material.SetFloat("_Effect", Mathf.Lerp(min, max, pulse));
    }
}
