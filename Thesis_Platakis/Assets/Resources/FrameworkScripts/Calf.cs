using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Calf : Muscle
{
    // Start is called before the first frame update
    void Start()
    {
        print("mphka calf");
        body = GameObject.Find("Skeleton_Reference1").GetComponent<Body>();
        name = "Calf";
        tma = GameObject.Find("Skeleton_Reference1").GetComponent<TextureMuscleActivator>();
        jointsToEvaluate = new GameObject[2];
        thresholds = new float[2, 2];
        jointsToEvaluate[0] = body.bodyparts["RFoot"];
        jointsToEvaluate[1] = body.bodyparts["LFoot"];
        thresholds[0, 0] = 40f;
        thresholds[0, 1] = 20f;
        thresholds[1, 0] = 40f;
        thresholds[1, 1] = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        tma.Evaluate(jointsToEvaluate, thresholds);
    }
}
