using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Dorsal : Muscle
{
    // Start is called before the first frame update
    void Start()
    {
        print("mphka dorsals");
        body = GameObject.Find("Skeleton_Reference1").GetComponent<Body>();
        name = "Dorsals";
        tma = GameObject.Find("Skeleton_Reference1").GetComponent<TextureMuscleActivator>();
        jointsToEvaluate = new GameObject[1];
        thresholds = new float[1, 2];
        jointsToEvaluate[0] = body.bodyparts["Spine"];
        thresholds[0, 0] = 15f;
        thresholds[0, 1] = 45f;
    }

    // Update is called once per frame
    void Update()
    {
        tma.Evaluate(jointsToEvaluate, thresholds);
    }
}