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
        jointActions[b.bodyparts["LArm"]] = HandleArm;
        jointActions[b.bodyparts["RArm"]] = HandleArm;
        jointActions[b.bodyparts["LForeArm"]] = HandleForeArm;
        jointActions[b.bodyparts["RForeArm"]] = HandleForeArm;
    }

    private void HandleArm(Transform thresholds)
    {
        // 98= max intensity, min intensity: 173 for shoulder
        string jname;
        if (thresholds.gameObject.name == "Skeleton_LeftArm") jname = "LArm";
        else jname = "RArm";
        Vector3 rotation = b.bodyparts[jname].transform.rotation.eulerAngles;
        float distance = thresholds.rotation.eulerAngles.x - rotation.x;
        float distancel = Mathf.InverseLerp(0f, 62f, distance);
        print("Distance 0-1: " + distancel);
        Activate(1 - distancel);
    }

    private void HandleForeArm(Transform thresholds)
    {
        // 98= max intensity, min intensity: 173 for shoulder
        string jname;
        if (thresholds.gameObject.name == "Skeleton_LeftForeArm") jname = "LForeArm";
        else jname = "RForeArm";
        Vector3 rotation = b.bodyparts[jname].transform.rotation.eulerAngles;
        float distance = thresholds.rotation.eulerAngles.x - rotation.x;
        float distancel = Mathf.InverseLerp(0f, 62f, distance);
        print("Distance 0-1: " + distancel);
        Activate(1 - distancel);
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
                Debug.Log("This joint is not yet implemented");
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
