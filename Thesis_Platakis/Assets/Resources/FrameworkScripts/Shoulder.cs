using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder : Muscle
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("mphka shoulder");
        body = GameObject.Find("Skeleton_Reference1").GetComponent<Body>();
        name = "Shoulder";
        tma = GameObject.Find("Skeleton_Reference1").GetComponent<TextureMuscleActivator>();
        jointsToEvaluate = new GameObject[4];
        thresholds = new float[4, 2];
        jointsToEvaluate[0] = body.bodyparts["RArm"];
        jointsToEvaluate[1] = body.bodyparts["LArm"];
        jointsToEvaluate[2] = body.bodyparts["RArm"];
        jointsToEvaluate[3] = body.bodyparts["LArm"];
        thresholds[0, 0] = 25f;
        thresholds[0, 1] = 90f;
        thresholds[1, 0] = 25f;
        thresholds[1, 1] = 90f;
        thresholds[2, 0] = 65f;
        thresholds[2, 1] = 0f;
        thresholds[3, 0] = 65f;
        thresholds[3, 1] = 0f;

    }
    
    // Update is called once per frame
    void Update()
    {
        tma.Evaluate(jointsToEvaluate, thresholds);
    }
}
