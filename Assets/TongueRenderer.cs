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
        lines.numPositions = transform.childCount + 1;
        lines.SetPosition(0, transform.position);
        for (int tongueIndex = 0; tongueIndex < transform.childCount; tongueIndex++)
        {
            lines.SetPosition(tongueIndex+1, transform.GetChild(tongueIndex).position);
        }
	}
}
