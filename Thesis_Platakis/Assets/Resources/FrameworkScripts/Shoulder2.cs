using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder2 : Muscle
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("mphka shoulder2");
        body = GameObject.Find("OneSkeleton_Reference2").GetComponent<Body>();
        thr = GameObject.Find("OneSkeleton_Reference2").GetComponent<Thresholds>();
        name = "Shoulder";
        int i = 1;
        tma = GameObject.Find("OneSkeleton_Reference2").GetComponent<TextureMuscleActivator>();
        jointsToEvaluate = new GameObject[4];
        thresholds = new float[4, 2];
        jointsToEvaluate[0] = body.bodyparts["RArm2"];
        jointsToEvaluate[1] = body.bodyparts["LArm2"];
        jointsToEvaluate[2] = body.bodyparts["RArm2"];
        jointsToEvaluate[3] = body.bodyparts["LArm2"];
        thresholds[0, 0] = thr.thresholds[name + i][0];
        thresholds[0, 1] = thr.thresholds[name + i][1];
        thresholds[1, 0] = thr.thresholds[name + i][0];
        thresholds[1, 1] = thr.thresholds[name + i][1];
        i++;
        thresholds[2, 0] = thr.thresholds[name + i][0];
        thresholds[2, 1] = thr.thresholds[name + i][1];
        thresholds[3, 0] = thr.thresholds[name + i][0];
        thresholds[3, 1] = thr.thresholds[name + i][1];

    }

    // Update is called once per frame
    void Update()
    {
        tma.Evaluate(jointsToEvaluate, thresholds);
    }
}
