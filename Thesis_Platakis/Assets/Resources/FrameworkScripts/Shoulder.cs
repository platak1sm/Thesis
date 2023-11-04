using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder : Muscle
{
    // Start is called before the first frame update
    void Start()
    {
        name = "Shoulder";
        jointsToEvaluate[0] = body.bodyparts["LArm"];
        jointsToEvaluate[1] = body.bodyparts["LShoulder"];
        jointsToEvaluate[2] = body.bodyparts["LForeArm"];

    }

    // Update is called once per frame
    void Update()
    {
        tma.Evaluate(jointsToEvaluate, thresholds);
    }
}
