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
    Material m;
    Thresholds thr;
    bool isBenting = false, isLyingSupine = false, isLyingProne = false, isStanding = true, isActivatedR = false, isActivatedL = false, isActivated = false;
    private void Awake()
    {
        b = GameObject.Find("Skeleton_Reference1").GetComponent<Body>();
    }

    // Start is called before the first frame update
    void Start()
    {
        thr = GameObject.Find("Skeleton_Reference1").GetComponent<Thresholds>();
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
        jointActions[b.bodyparts["Spine"]] = HandleCore;
    }

    private void HandleShoulder(GameObject joint, float[] thresholds)
    {

    }

    private void HandleArm(GameObject joint, float[] thresholds) //90-115 310 265
    {
        string jname, jname2;
        GameObject muscle,muscle2,muscle3;
        bool isLeft = false; 
        float distance, distancel;
        if (joint.name == "Skeleton_LeftArm")
        {
            jname = "LArm";
            jname2 = "LForeArm";
            isLeft = true;
            muscle = GameObject.Find("LShoulderSphere");
            muscle2 = GameObject.Find("LChestSphere");
            muscle3 = GameObject.Find("LBackSphere");
            isActivated = isActivatedL;
        }
        else {
            jname = "RArm";
            jname2 = "RForeArm";
            muscle = GameObject.Find("RShoulderSphere");
            muscle2 = GameObject.Find("RChestSphere");
            muscle3 = GameObject.Find("RBackSphere");
            isActivated = isActivatedR;
        }

        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 rotation2 = b.bodyparts[jname2].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;
        Vector3 spinerotation = b.bodyparts["Spine"].transform.localRotation.eulerAngles;

        if (thresholds[1] > thresholds[0])
        {
            if (thresholds[1] > 90)
            {
                distance = thresholds[1] - rotation.z;
                if (distance <= thresholds[1] - thresholds[0] && distance >= 0 && rotation2.z >= thr.thresholds["Bicep"][1] && rotation2.z <= thr.thresholds["Bicep"][0])
                {
                    //print("Distance of joint " + jname +": "+ distance);
                    distancel = Mathf.InverseLerp(0f, thresholds[1] - thresholds[0], distance);
                    //print("Distance 0-1 of joint " + jname + ": " + distancel);
                    Activate(1 - distancel, muscle3);
                }
                else
                {
                    Activate(0, muscle3);
                }
            }
            else
            {
                distance = thresholds[1] - rotation.x;
                if (distance <= thresholds[1] - thresholds[0] && distance >= 0)
                {
                    //print("Distance of joint " + jname +": "+ distance);
                    distancel = Mathf.InverseLerp(0f, thresholds[1] - thresholds[0], distance);
                    //print("Distance 0-1 of joint " + jname + ": " + distancel);
                    Activate(1 - distancel, muscle);
                    if (isLeft) isActivatedL = true;
                    else isActivatedR = true;
                }
                else
                {
                    if (isLeft) isActivatedL = false;
                    else isActivatedR = false;
                    Activate(0, muscle);
                }
            }
        }
        else
        {
            distance = thresholds[1] - rotation.z;

            if (distance >= thresholds[1] - thresholds[0] && distance <= 0 && (spinerotation.z >= thr.thresholds["StandingSpine"][0] || spinerotation.z <= thr.thresholds["StandingSpine"][1]))
            {
                //print("Distance of joint " + jname +": "+ distance);
                distancel = Mathf.InverseLerp(thresholds[1] - thresholds[0], 0f, distance);
                //print("Distance 0-1 of joint " + jname + ": " + distancel);
                Activate(distancel, muscle);

                if (hiprotation.z <= thr.thresholds["LyingSupine"][1] && hiprotation.z >= thr.thresholds["LyingSupine"][0])
                {
                    distancel = Mathf.InverseLerp(thresholds[1] - thresholds[0], 0f, distance);
                    //Debug.Log("Distance 0-1 of joint CHEST: " + distancel);
                    Activate(distancel, muscle2);
                }
                else
                {
                    Activate(0, muscle2);
                }
            }
            else if (!isActivated)
            {
                Activate(0, muscle);
                Activate(0, muscle2);
            }
        }
    }
 
    private void HandleForeArm(GameObject joint, float[] thresholds)
    {
        string jname,jname2;
        float distance, distancel;
        GameObject muscle;
        bool isLeft = false;
        if (joint.name == "Skeleton_LeftForeArm") {
            jname = "LForeArm";
            jname2 = "LArm";
            isLeft = true;
        }
        else {
            jname = "RForeArm";
            jname2 = "RArm";
        }
        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 rotation2 = b.bodyparts[jname2].transform.localRotation.eulerAngles;
        Vector3 spinerotation = b.bodyparts["Spine"].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;
        distance = thresholds[1] - rotation.z;
        if (thresholds[1] > thresholds[0])
        {
            if (isLeft) muscle = GameObject.Find("LTricepSphere");
            else muscle = GameObject.Find("RTricepSphere");
            if (hiprotation.z >= thr.thresholds["StandingHip"][0] && hiprotation.z <= thr.thresholds["StandingHip"][1])
            {

                if (distance <= thresholds[1] - thresholds[0] && distance >= 0)
                {
                    if (spinerotation.z <= thr.thresholds["Benting"][1] && spinerotation.z >= thr.thresholds["Benting"][0])
                    {
                        if (!isBenting)
                        {
                            print("IS BENTING NOW");
                            isBenting = true;
                        }
                        //print("Distance of joint " + jname + ": " + distance);
                        distancel = Mathf.InverseLerp(0f, thresholds[1] - thresholds[0], distance);
                        //print("Distance 0-1 of joint " + jname + ": " + distancel);
                        Activate(1 - distancel, muscle);
                    }
                    else
                    {
                        if (isBenting)
                        {
                            print("ISN'T BENTING ANYMORE");
                            isBenting = false;
                        }
                        Activate(0, muscle);
                    }
                }
                else Activate(0, muscle);
            }
            else Activate(0, muscle);
        }
        else
        {
            if (isLeft) muscle = GameObject.Find("LBicepSphere");
            else muscle = GameObject.Find("RBicepSphere");
            
            if (distance > thresholds[1] - thresholds[0] && distance <= 0 && rotation2.x <= thr.thresholds["Shoulder1"][0])
            {
                    //Debug.Log("Distance of joint " + jname + ": " + distance);
                    distancel = Mathf.InverseLerp(thresholds[1] - thresholds[0], 0f, distance);
                    //Debug.Log("Distance 0-1 of joint " + jname + ": " + distancel);
                    Activate(distancel, muscle);
            }
            else if (distance > 0)
            {
                //Debug.Log("Distance of joint " + jname + ": " + distance);
                distancel = Mathf.InverseLerp(0f, thresholds[0] - thresholds[1], distance);
                //Debug.Log("Distance 0-1 of joint " + jname + ": " + distancel);
                Activate(1-distancel, muscle);
            }
            else Activate(0, muscle);

        }
    }


    private void HandleUpLeg(GameObject joint, float[] thresholds)
    {

    }

    private void HandleLeg(GameObject joint, float[] thresholds)
    {
        string jname;
        float distance, distancel, d1;
        GameObject muscle;
        bool isLeft = false;

        if (joint.name == "Skeleton_LeftLeg")
        {
            jname = "LLeg";
            isLeft = true;
        }
        else jname = "RLeg";

        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;

        distance = (thresholds[1] - rotation.z + 360) % 360;
        d1 = (thr.thresholds["Quad"][1] - thr.thresholds["Quad"][0] + 360) % 360;

        if (isLeft) muscle = GameObject.Find("LQuadSphere");
        else muscle = GameObject.Find("RQuadSphere");

        if (distance <= d1 &&  thresholds[1] == thr.thresholds["Quad"][1])
        {
            if (hiprotation.z >= thr.thresholds["StandingHip"][0] && hiprotation.z <= thr.thresholds["StandingHip"][1])
            {

                if (distance != d1)
                {
                    //if(isSitting) more ROM
                    //if not:
                    //print("Distance of joint " + jname + ": " + distance);
                    distancel = Mathf.InverseLerp(0f, (thresholds[1] - thresholds[0] + 360) % 360, distance);
                    //print("Distance 0-1 of joint " + jname + ": " + distancel);
                    Activate(1 - distancel, muscle);
                }
                else Activate(0, muscle);
            }
            else Activate(0, muscle);
        }

        else if (thresholds[1] == thr.thresholds["Quad"][1]) Activate(0, muscle);

        else
        {
            if (isLeft) muscle = GameObject.Find("LHamstringSphere");
            else muscle = GameObject.Find("RHamstringSphere");
            distance = thresholds[1] - rotation.z;
            if (distance >= thresholds[1] - thresholds[0] && distance <= 0)
            {
                //Debug.Log("Distance of joint " + jname + ": " + distance);
                distancel = Mathf.InverseLerp(thresholds[1] - thresholds[0], 0f, distance);
                //Debug.Log("Distance 0-1 of joint " + jname + ": " + distancel);
                Activate(distancel, muscle);
            }
            else if (distance > 0)
            {
                //Debug.Log("Distance of joint " + jname + ": " + distance);
                distancel = Mathf.InverseLerp(0f, thresholds[0] - thresholds[1], distance);
                //Debug.Log("Distance 0-1 of joint " + jname + ": " + distancel);
                Activate(1 - distancel, muscle);
            }
            else Activate(0, muscle);
            
        }
    }

    private void HandleFoot(GameObject joint, float[] thresholds)
    {
        string jname;
        float distance, distancel;
        GameObject muscle;
        bool isLeft = false;
        if (joint.name == "Skeleton_LeftFoot")
        {
            jname = "LFoot";
            isLeft = true;
        }
        else jname = "RFoot";

        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;

        distance = thresholds[1] - rotation.z;
        if (isLeft) muscle = GameObject.Find("LCalfSphere");
        else muscle = GameObject.Find("RCalfSphere");

        if (distance > thresholds[1] - thresholds[0])
        {
            if (hiprotation.z >= thr.thresholds["StandingHip"][0] && hiprotation.z <= thr.thresholds["StandingHip"][1])
            {
                //Debug.Log("Distance of joint " + jname + ": " + distance);
                distancel = Mathf.InverseLerp(thresholds[1] - thresholds[0], 0f, distance);
                //Debug.Log("Distance 0-1 of joint " + jname + ": " + distancel);
                Activate(distancel, muscle);
            }
        }
        else Activate(0, muscle);

    }

    private void HandleCore(GameObject joint, float[] thresholds)
    {
        float distance, distancel;
        GameObject muscle;

        Vector3 rotation = b.bodyparts["Spine"].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;
        distance = thresholds[1] - rotation.z;

        if (thresholds[1] > thresholds[0])
        {
            muscle = GameObject.Find("DorsalSphere");
            if (distance <= thresholds[1] - thresholds[0] && rotation.z <= thr.thresholds["Arching"][1])
            {
                if (hiprotation.z <= thr.thresholds["LyingProne"][1] && hiprotation.z >= thr.thresholds["LyingProne"][0])
                {
                    if (!isLyingProne)
                    {
                        print("IS LYING PRONE NOW");
                        isLyingProne = true;
                    }
                    //print("Distance of joint " + jname + ": " + distance);
                    distancel = Mathf.InverseLerp(0f, thresholds[1] - thresholds[0], distance);
                    //print("Distance 0-1 of joint " + jname + ": " + distancel);
                    Activate(1 - distancel, muscle);
                }
                else
                {
                    if (!isLyingProne)
                    {
                        print("ISN'T LYING PRONE ANYMORE");
                        isLyingProne = false;
                    }
                    Activate(0, muscle);
                }
            }
            else Activate(0, muscle);

        }
        else
        {
            muscle = GameObject.Find("AbsSphere");
            if (distance >= thresholds[1] - thresholds[0] && rotation.z >= thr.thresholds["Abs"][1])
            {
                if (hiprotation.z <= thr.thresholds["LyingSupine"][1] && hiprotation.z >= thr.thresholds["LyingSupine"][0])
                {
                    if (!isLyingSupine) print("IS LYING SUPINE NOW");
                    isLyingSupine = true;
                    //Debug.Log("Distance of joint Spine: " + distance);
                    distancel = Mathf.InverseLerp(thresholds[1] - thresholds[0], 0f, distance);
                    //Debug.Log("Distance 0-1 of joint Spine: " + distancel);
                    Activate(distancel, muscle);
                }
                else
                {
                    if (!isLyingSupine)
                    {
                        print("ISN'T LYING SUPINE ANYMORE");
                        isLyingSupine = false;
                    }
                    Activate(0, muscle);
                }
            }
            else Activate(0, muscle);
        }
    }


    public override void Evaluate(GameObject[] joints, float[,] thresholds)
    {
        float[] thresholdsarr = new float[2];
        if (2 * joints.Length != thresholds.Length)
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
        m = muscle.GetComponent<Renderer>().material;
        if (intensity > 0)
        {
            Color lerpedColor = Color.Lerp(Color.yellow, Color.red, intensity);
            //Debug.Log("Activated " + muscle.name + " with intensity " + intensity);
            m.color = lerpedColor;
        }
        else if (intensity == 0)
        {
            m.color = Color.white;
        }

    }


}
