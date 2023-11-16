using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Hamstring : Muscle
{
    // Start is called before the first frame update
    void Start()
    {
        print("mphka hamstring");
        body = GameObject.Find("Skeleton_Reference1").GetComponent<Body>();
        name = "Hamstring";
        tma = GameObject.Find("Skeleton_Reference1").GetComponent<TextureMuscleActivator>();
        jointsToEvaluate = new GameObject[2];
        thresholds = new float[2, 2];
        jointsToEvaluate[0] = body.bodyparts["RLeg"];
        jointsToEvaluate[1] = body.bodyparts["LLeg"];
        thresholds[0, 0] = 310f;
        thresholds[0, 1] = 245f;
        thresholds[1, 0] = 310f;
        thresholds[1, 1] = 245f;
    }

    // Update is called once per frame
    void Update()
    {
        tma.Evaluate(jointsToEvaluate, thresholds);
    }
}
