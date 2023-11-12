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
        jointsToEvaluate = new GameObject[2];
        thresholds = new float[2, 2];
        jointsToEvaluate[0] = body.bodyparts["RArm"];
        jointsToEvaluate[1] = body.bodyparts["LArm"];
        //jointsToEvaluate[1] = body.bodyparts["LShoulder"];
        //jointsToEvaluate[2] = body.bodyparts["LForeArm"];
        thresholds[0, 0] = 25f;
        thresholds[0, 1] = 90f;
        thresholds[1, 0] = 25f;
        thresholds[1, 1] = 90f;
    }
    
    // Update is called once per frame
    void Update()
    {
        tma.Evaluate(jointsToEvaluate, thresholds);
    }
}
