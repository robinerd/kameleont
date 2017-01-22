using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsing : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public float phaseOffset = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Here we'll handle fading of instruments based on in-game progress.
        float timeFactor = (Music.instance.baseMusic.time - phaseOffset + 0.4f) * Mathf.PI * 2 * (Music.BPM / 60.0f / 2);
        float pulse = Mathf.Sin(timeFactor);
        pulse = pulse * 0.5f + 0.5f; //Transform from -1..1 to 0..1
        UpdatePulsing(pulse);
    }

    /// Called every update with "pulse" following a sine wave between [0 .. 1], synchronized with music.
    /// Subclasses will use "pulse" in different ways, for example scale or transparency.
    protected virtual void UpdatePulsing(float pulse)
    {
    }
}
