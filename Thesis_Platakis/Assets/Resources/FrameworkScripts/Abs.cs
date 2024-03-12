using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Abs : Muscle
{
    // Start is called before the first frame update
    void Start()
    {
        print("mphka abs");
        body = GameObject.Find("OneSkeleton_Reference").GetComponent<Body>();
        thr = GameObject.Find("OneSkeleton_Reference").GetComponent<Thresholds>();
        name = "Abs";
        tma = GameObject.Find("OneSkeleton_Reference").GetComponent<TextureMuscleActivator>();
        jointsToEvaluate = new GameObject[1];
        thresholds = new float[1, 2];
        jointsToEvaluate[0] = body.bodyparts["Spine"];
        thresholds[0, 0] = thr.thresholds[name][0];
        thresholds[0, 1] = thr.thresholds[name][1];
    }

    // Update is called once per frame
    void Update()
    {
        tma.Evaluate(jointsToEvaluate, thresholds);
    }
}