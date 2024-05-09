using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Bicep2 : Muscle
{
    // Start is called before the first frame update
    void Start()
    {
        print("mphka bicep2");
        body = GameObject.Find("OneSkeleton_Reference2").GetComponent<Body>();
        thr = GameObject.Find("OneSkeleton_Reference2").GetComponent<Thresholds>();
        name = "Bicep";
        tma = GameObject.Find("OneSkeleton_Reference2").GetComponent<TextureMuscleActivator>();
        jointsToEvaluate = new GameObject[2];
        thresholds = new float[2, 2];
        jointsToEvaluate[0] = body.bodyparts["RForeArm2"];
        jointsToEvaluate[1] = body.bodyparts["LForeArm2"];
        thresholds[0, 0] = thr.thresholds[name][0];
        thresholds[0, 1] = thr.thresholds[name][1];
        thresholds[1, 0] = thr.thresholds[name][0];
        thresholds[1, 1] = thr.thresholds[name][1];
    }

    // Update is called once per frame
    void Update()
    {
        tma.Evaluate(jointsToEvaluate, thresholds);
    }
}
