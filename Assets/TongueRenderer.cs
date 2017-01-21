using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TongueRenderer : MonoBehaviour {

    LineRenderer lines;

	// Use this for initialization
	void Start ()
    {
        lines = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        //TONGUE RENDERER OFF WHEN TONGUE IS IN MOUTH
        bool tongueInMouth = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 localPos = transform.GetChild(i).transform.localPosition;
            if (localPos.y > 0.5f || localPos.magnitude > 7.0f)
            {
                tongueInMouth = false;
            }
        }
        lines.enabled = !tongueInMouth;

        lines.numPositions = transform.childCount + 1;
        lines.SetPosition(0, transform.position);
        for (int tongueIndex = 0; tongueIndex < transform.childCount; tongueIndex++)
        {
            lines.SetPosition(tongueIndex+1, transform.GetChild(tongueIndex).position);
        }
	}
}
