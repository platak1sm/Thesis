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
        body = GameObject.Find("OneSkeleton_Reference").GetComponent<Body>();
        thr = GameObject.Find("OneSkeleton_Reference").GetComponent<Thresholds>();
        name = "Calf";
        tma = GameObject.Find("OneSkeleton_Reference").GetComponent<TextureMuscleActivator>();
        jointsToEvaluate = new GameObject[2];
        thresholds = new float[2, 2];
        jointsToEvaluate[0] = body.bodyparts["RFoot"];
        jointsToEvaluate[1] = body.bodyparts["LFoot"];
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
