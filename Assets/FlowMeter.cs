using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlowMeter : MonoBehaviour {

    public static float flow = 0;
    public float flowLimit = 50;
    public float maximumScaleY = 32;

    public Image fillLeft;
    public Image fillRight;
    public Text[] multipliers;

    // Use this for initialization
    void Start() {
        ResetFlow();
    }

    // Update is called once per frame
    void Update() {
        if (calcFlowFactor() <= -1.00001f)
        {
            GameOver();
        }
        else
        {
            checkGoBack();
        }

        flow = Mathf.Clamp(flow, -flowLimit, flowLimit);

        var flowFill =  Mathf.InverseLerp(-flowLimit, flowLimit, flow);
        fillLeft.fillAmount = flowFill;
        fillRight.fillAmount = flowFill;
        foreach (Text t in multipliers)
        {
            string text = "x " + string.Format("{0:0.##}", GetMultiplier());
            Debug.Log("Before: "+text);
            t.text = text;
            Debug.Log("After: "+t.text);
        }

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
        SceneManager.LoadScene("GameOver");
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

    private void checkGoBack()
    {
        if (Input.GetButtonDown("GoToMainMenu"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
