using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using UnityEditor;
using UnityEngine;
//using static UnityEditor.FilePathAttribute;

public class TextureMuscleActivator : MuscleActivator
{
    Texture tex;
    Body b;
    private Dictionary<GameObject, Action<GameObject, float[]>> jointActions = new Dictionary<GameObject, Action<GameObject, float[]>>();
    Material m,init;
    private void Awake()
    {
        b = GameObject.Find("Skeleton_Reference1").GetComponent<Body>();
    }

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
        //init = GameObject.Find("RShoulderSphere").GetComponent<Renderer>().material;
    }

    private void HandleShoulder(GameObject joint, float[] thresholds)
    {

    }

    private void HandleArm(GameObject joint, float[] thresholds)
    {   // Vector3(2.00000381, 83.4130096, 73.072998),  Vector3(86.099968,83.4129944,73.0729904) Vector3(82.260994,31.6448059,15.1833076)
        // 90= max intensity, min intensity: 25 for shoulder
        string jname;
        if (joint.name == "Skeleton_LeftArm") jname = "LArm";
        else jname = "RArm";
        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        print("CURRENT ROTATION of joint " + jname + ": " + rotation.x);
        float distance = thresholds[1] - rotation.x;
        if (distance <= 65 && distance >=0) {
            print("Distance of joint " + jname +": "+ distance);
            float distancel = Mathf.InverseLerp(0f, 65f, distance);
            print("Distance 0-1 of joint " + jname + ": " + distancel);
            Activate(1 - distancel,joint);
        }
        else
        {
            Activate(0,joint);
        }
        
    }
 
    private void HandleForeArm(GameObject joint, float[] thresholds)
    {
        // inital arm rotation for shoulder press Vector3(27.6879864, 357.107605, 2.22405672) inital forearm rot: Vector3(350.849213,49.7152138,245.169556)
        // 98= max intensity, min intensity: 173 for shoulder
        // -185= min intensity , max:Vector3(27.6880131,357.108002,286.700012)
        string jname;
        if (joint.name == "Skeleton_LeftForeArm") jname = "LForeArm";
        else jname = "RForeArm";
        //Vector3 rotation = b.bodyparts[jname].transform.rotation.eulerAngles;
        //float distance = thresholds.rotation.eulerAngles.x - rotation.x;
        //float distancel = Mathf.InverseLerp(0f, 62f, distance);
        //print("Distance 0-1: " + distancel);
        //Activate(1 - distancel);
    }


    private void HandleUpLeg(GameObject joint, float[] thresholds)
    {

    }

    private void HandleLeg(GameObject joint, float[] thresholds)
    {

    }

    private void HandleFoot(GameObject joint, float[] thresholds)
    {

    }

    public override void Evaluate(GameObject[] joints, float[,] thresholds)
    {
        float[] thresholdsarr = new float[2];
        if (2*joints.Length != thresholds.Length)
        {
            Debug.LogError("The number of joints and thresholds should be the same.");
            return;
        }
        for (int i = 0; i < joints.Length; i++)
        {
            if (jointActions.ContainsKey(joints[i]))
            {
                thresholdsarr[0] = thresholds[i, 0];
                thresholdsarr[1] = thresholds[i, 1];
                jointActions[joints[i]](joints[i], thresholdsarr);
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

    public override void Activate(float intensity, GameObject muscle)
    {
        if (intensity > 0)
        {
            Color lerpedColor = Color.Lerp(Color.yellow, Color.red, intensity);
            if (muscle.name.Contains("Left")) {
                Debug.Log("Activated Left Shoulder with intensity " + intensity);
                m = GameObject.Find("LShoulderSphere").GetComponent<Renderer>().material;
            }
            else
            {
                Debug.Log("Activated Right Shoulder with intensity " + intensity);
                m = GameObject.Find("RShoulderSphere").GetComponent<Renderer>().material;
            }
            m.color = lerpedColor;
        }
        else if (intensity == 0)
        {
            if (muscle.name.Contains("Left"))
            {
                m = GameObject.Find("LShoulderSphere").GetComponent<Renderer>().material;
            }
            else
            {
                m = GameObject.Find("RShoulderSphere").GetComponent<Renderer>().material;
            }
            m.color = Color.white;
        }
        
    }
        

}
