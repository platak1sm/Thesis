using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
//using static UnityEditor.FilePathAttribute;

public class TextureMuscleActivator : MuscleActivator
{
    Texture tex;
    Body b;
    private Dictionary<GameObject, Action<Transform>> jointActions = new Dictionary<GameObject, Action<Transform>>();

    // Start is called before the first frame update
    void Start()
    {
        jointActions[b.bodyparts["LShoulder"]] = HandleShoulder;
        jointActions[b.bodyparts["RShoulder"]] = HandleShoulder;
        jointActions[b.bodyparts["LArm"]] = HandleArm;
        jointActions[b.bodyparts["RArm"]] = HandleArm;
        jointActions[b.bodyparts["LForeArm"]] = HandleForeArm;
        jointActions[b.bodyparts["RForeArm"]] = HandleForeArm;
        jointActions[b.bodyparts["LUpLeg"]] = HandleUpLeg;
        jointActions[b.bodyparts["RUpLeg"]] = HandleUpLeg;
        jointActions[b.bodyparts["LLeg"]] = HandleLeg;
        jointActions[b.bodyparts["RLeg"]] = HandleLeg;
        jointActions[b.bodyparts["LFoot"]] = HandleFoot;
        jointActions[b.bodyparts["RFoot"]] = HandleFoot;

    }

    private void HandleShoulder(Transform thresholds)
    {

    }

    private void HandleArm(Transform thresholds)
    {   // Vector3(2.00000381, 83.4130096, 73.072998),  Vector3(86.099968,83.4129944,73.0729904) Vector3(82.260994,31.6448059,15.1833076)
        // 98= max intensity, min intensity: 170 for shoulder
        string jname;
        if (thresholds.gameObject.name == "Skeleton_LeftArm") jname = "LArm";
        else jname = "RArm";
        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        float distance = thresholds.rotation.eulerAngles.x - rotation.x;
        float distancel = Mathf.InverseLerp(0f, 62f, distance);
        print("Distance 0-1: " + distancel);
        Activate(1 - distancel);
    }
 
    private void HandleForeArm(Transform thresholds)
    {
        // inital arm rotation for shoulder press Vector3(27.6879864, 357.107605, 2.22405672) inital forearm rot: Vector3(350.849213,49.7152138,245.169556)
        // 98= max intensity, min intensity: 173 for shoulder
        // -185= min intensity , max:Vector3(27.6880131,357.108002,286.700012)
        string jname;
        if (thresholds.gameObject.name == "Skeleton_LeftForeArm") jname = "LForeArm";
        else jname = "RForeArm";
        //Vector3 rotation = b.bodyparts[jname].transform.rotation.eulerAngles;
        //float distance = thresholds.rotation.eulerAngles.x - rotation.x;
        //float distancel = Mathf.InverseLerp(0f, 62f, distance);
        //print("Distance 0-1: " + distancel);
        //Activate(1 - distancel);
    }


    private void HandleUpLeg(Transform thresholds)
    {

    }

    private void HandleLeg(Transform thresholds)
    {

    }

    private void HandleFoot(Transform thresholds)
    {

    }

    public override void Evaluate(GameObject[] joints, Transform[] thresholds)
    {
        if (joints.Length != thresholds.Length)
        {
            Debug.LogError("The number of joints and thresholds should be the same.");
            return;
        }
        for (int i = 0; i < joints.Length; i++)
        {
            if (jointActions.ContainsKey(joints[i]))
            {
                jointActions[joints[i]](thresholds[i]);
            }
            else
            {
                Debug.Log("This joint is not yet implemented.");
            }
        }
    }

    public override void Activate()
    {
        throw new System.NotImplementedException();
    }

    public override void Activate(float intensity)
    {
        Debug.Log("Activated with intensity " + intensity);
    }

}
