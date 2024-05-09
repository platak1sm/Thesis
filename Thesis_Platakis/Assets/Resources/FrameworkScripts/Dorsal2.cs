using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Dorsal2 : Muscle
{
    // Start is called before the first frame update
    void Start()
    {
        print("mphka dorsals2");
        body = GameObject.Find("OneSkeleton_Reference2").GetComponent<Body>();
        thr = GameObject.Find("OneSkeleton_Reference2").GetComponent<Thresholds>();
        name = "Dorsal";
        tma = GameObject.Find("OneSkeleton_Reference2").GetComponent<TextureMuscleActivator>();
        jointsToEvaluate = new GameObject[1];
        thresholds = new float[1, 2];
        jointsToEvaluate[0] = body.bodyparts["Spine21"];
        thresholds[0, 0] = thr.thresholds[name][0];
        thresholds[0, 1] = thr.thresholds[name][1];
    }

    // Update is called once per frame
    void Update()
    {
        tma.Evaluate(jointsToEvaluate, thresholds);
    }
}