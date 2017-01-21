using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour {


    public Transform tonguePartPrefab;
    public Transform tongueTarget;
    public int numberOfTongueParts = 5;
    public float tongueMovementForce = 500.0f;
    public float tongueSpeedSideways = 0.5f; // Max speed sideways, units per second
    public float tongueSpeedForward = 3.0f; // Max speed forward, units per second
    public float sidewaysAccelPerKeyPress = 0.2f; // Added to tongueDirection (always between -1 .. 1) per input press
    public float forwardAccelPerKeyPress = 0.08f;

    Transform tongueTip = null;

    const float STOP_LICKING_COOLDOWN = 0.4f;
    float tongueDirection = 0; //positive is right, negative is left. Always between (-1 .. 1)
    float forwardMovementFactor = 0.0f; // units per second
    bool isLicking = false;
    float lickingInputCooldown = 0;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < numberOfTongueParts; i++)
        {
            AddTonguePart();
        }
    }

    void Update()
    {
        // hacky snap to position behind the chameleon sprite
        Vector3 tonguePosInSprite = transform.parent.position + Vector3.up * 0.4f;
        Ray ray = new Ray(Camera.main.transform.position, (tonguePosInSprite - Camera.main.transform.position).normalized);
        Plane slurpPlane = new Plane(-Vector3.forward, Vector3.zero);
        float depth;
        slurpPlane.Raycast(ray, out depth);
        transform.position = ray.GetPoint(depth);

        int inputCount = 0;

        if (Input.GetButtonDown("TongueLeft"))
        {
            inputCount++;
            if(tongueDirection > 0.5f)
            {
                tongueDirection -= 0.5f;
            }
            tongueDirection -= sidewaysAccelPerKeyPress;
        }
        if (Input.GetButtonDown("TongueRight"))
        {
            inputCount++;
            if (tongueDirection < -0.5f)
            {
                tongueDirection += 0.5f;
            }
            tongueDirection += sidewaysAccelPerKeyPress;
        }
        tongueDirection = Mathf.Clamp(tongueDirection, -1.0f, 1.0f);

        if (inputCount > 0)
        {
            if(!isLicking)
            {
                forwardMovementFactor = 0.2f;
            }
            isLicking = true;
            lickingInputCooldown = STOP_LICKING_COOLDOWN;
            forwardMovementFactor += forwardAccelPerKeyPress * inputCount;
        }
        forwardMovementFactor *= 0.99f;

        lickingInputCooldown -= Time.deltaTime;

        if (lickingInputCooldown <= 0.0f)
        {
            isLicking = false;
            tongueDirection = 0;
        }

        Vector3 tongueTargetVelocity;
        if (isLicking)
        {
            tongueTargetVelocity = Vector3.up * forwardMovementFactor * tongueSpeedForward + 
                                   Vector3.right * tongueDirection * tongueSpeedSideways;
        }
        else
        {
            tongueTargetVelocity = transform.position - tongueTarget.position;
        }
        tongueTarget.position += Time.deltaTime * tongueTargetVelocity;

        Vector3 fromRootToTarget = tongueTarget.position - transform.position;
        float tongueLength = fromRootToTarget.magnitude * 1.5f; //make the tongue longer than needed to get a relaxed and slurpy touch.
        float tonguePartLength = tongueLength / numberOfTongueParts;
        for (int i = 0; i < numberOfTongueParts; i++)
        {
            Transform tonguePart = transform.GetChild(i);
            tonguePart.GetComponent<SpringJoint>().minDistance = tonguePartLength * 0;
        }

        Vector3 fromTipToTarget = tongueTarget.position - tongueTip.position;
        tongueTip.GetComponent<Rigidbody>().AddForce(fromTipToTarget * tongueMovementForce, ForceMode.Acceleration);
    }

	void FixedUpdate () {
        //TODO:
        //Make tongue target move based on co-op input.


		//Apply force on tonguetip towards tongue target.
        //Extend min-distance on spring joint to let the tongue become longer, also based on input.
	}

    void AddTonguePart()
    {
        Transform tonguePart = GameObject.Instantiate(tonguePartPrefab, transform.position, Quaternion.identity, transform);

        if(tongueTip == null)
        {
            tongueTip = transform; //attach first tongue part to this object (Tongue root)
        }

        tonguePart.GetComponent<Joint>().connectedBody = tongueTip.GetComponent<Rigidbody>();
        tongueTip = tonguePart;
    }
}
