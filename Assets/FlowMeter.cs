using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMeter : MonoBehaviour {

    public static float flow = 0;
    public float flowLimit = 50;
    public float maximumScaleY = 32;

    // Use this for initialization
    void Start() {
        ResetFlow();
    }

    // Update is called once per frame
    void Update() {
        if(flow <= -1.00001f)
        {
            GameOver();
        }

        flow = Mathf.Clamp(flow, -flowLimit, flowLimit);
        float flowFactor = calcFlowFactor();
        transform.localScale = new Vector3(transform.localScale.x, flowFactor * maximumScaleY, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, flowFactor * maximumScaleY / 4, transform.position.z);
    }

    public void ResetFlow()
    {
        flow = 0;
    }

    float calcFlowFactor() {
        return flow / flowLimit; //From -limit .. limit to -1 .. 1
    }

    void GameOver()
    {
        //TODO!!!!!!!!!!!!!!!!!!!!!!
    }

    public float GetMultiplier()
    {
        float flowFactor = calcFlowFactor() + 0.00001f; //avoid float rounding issues
        float multiplier;

        if (flowFactor >= 1.0f)
            multiplier = 4.0f;
        else if (flowFactor >= 0.75f)
            multiplier = 3.0f;
        else if (flowFactor >= 0.5f)
            multiplier = 2.0f;
        else if (flowFactor >= 0.25f)
            multiplier = 1.5f;

        else if (flowFactor >= 0.0f)
            multiplier = 1.0f;

        else if (flowFactor >= -0.25f)
            multiplier = 0.75f;
        else if (flowFactor >= -0.5f)
            multiplier = 0.5f;
        else if (flowFactor >= -0.75f)
            multiplier = 0.25f;
        else
            multiplier = 0.1f;

        return multiplier;
    }
}
