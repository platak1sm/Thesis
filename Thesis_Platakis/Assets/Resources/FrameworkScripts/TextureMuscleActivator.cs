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
    Thresholds thr, thr2;
    bool isBenting = false, isLyingSupine = false, isLyingProne = false, isStanding = true, isActivatedR = false, isActivatedL = false, isActivated = false;
    bool isBenting2 = false, isLyingSupine2 = false, isLyingProne2 = false, isStanding2 = true, isActivatedR2 = false, isActivatedL2 = false, isActivated2 = false;
    private void Awake()
    {
        b = GameObject.Find("OneSkeleton_Reference").GetComponent<Body>();
    }

    // Start is called before the first frame update
    void Start()
    {
        thr = GameObject.Find("OneSkeleton_Reference").GetComponent<Thresholds>();
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

        //2nd model
        thr2 = GameObject.Find("OneSkeleton_Reference2").GetComponent<Thresholds>();
        jointActions[b.bodyparts["LShoulder2"]] = HandleShoulder;
        jointActions[b.bodyparts["RShoulder2"]] = HandleShoulder;
        jointActions[b.bodyparts["LArm2"]] = HandleArm2;
        jointActions[b.bodyparts["RArm2"]] = HandleArm2;
        jointActions[b.bodyparts["LForeArm2"]] = HandleForeArm2;
        jointActions[b.bodyparts["RForeArm2"]] = HandleForeArm2;
        jointActions[b.bodyparts["LUpLeg2"]] = HandleUpLeg2;
        jointActions[b.bodyparts["RUpLeg2"]] = HandleUpLeg2;
        jointActions[b.bodyparts["LLeg2"]] = HandleLeg2;
        jointActions[b.bodyparts["RLeg2"]] = HandleLeg2;
        jointActions[b.bodyparts["LFoot2"]] = HandleFoot2;
        jointActions[b.bodyparts["RFoot2"]] = HandleFoot2;
        jointActions[b.bodyparts["Spine21"]] = HandleCore2;
    }

    private void HandleShoulder(GameObject joint, float[] thresholds)
    {

    }

    private void HandleArm(GameObject joint, float[] thresholds) //90-115 310 265
    {
        string jname, jname2;
        GameObject muscle, muscle2, muscle3;
        bool isLeft = false;
        float distance, distancel;
        muscle3 = GameObject.Find("Back");
        //muscle11 = GameObject.Find("ShouldersM");
        //muscle12 = GameObject.Find("ChestM");
        //muscle13 = GameObject.Find("BackM");

        if (joint.name == "OneSkeleton_LeftArm")
        {
            jname = "LArm";
            jname2 = "LForeArm";
            isLeft = true;
            muscle = GameObject.Find("LShoulder");
            muscle2 = GameObject.Find("LChest");
            isActivated = isActivatedL;
        }
        else
        {
            jname = "RArm";
            jname2 = "RForeArm";
            muscle = GameObject.Find("RShoulder");
            muscle2 = GameObject.Find("RChest");
            isActivated = isActivatedR;
        }

        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 rotation2 = b.bodyparts[jname2].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;
        Vector3 spinerotation = b.bodyparts["Spine"].transform.localRotation.eulerAngles;

        if ((thresholds[1] > thresholds[0] || thresholds[1] == 275) && rotation.z > 280 && rotation.z < 290)
        {
            if (thresholds[1] < 275)
            {
                distance = thresholds[1] - rotation.x;
                if (distance <= thresholds[1] - thresholds[0] && distance >= 0) //rotation2.z >= thr.thresholds["Bicep"][1] && rotation2.z <= thr.thresholds["Bicep"][0]
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
                distance = rotation.x - thresholds[1];

                if (distance <= thresholds[0] - thresholds[1] && distance >= 0)
                {

                    distancel = Mathf.InverseLerp(0f, thresholds[0] - thresholds[1], distance);
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
            if (thresholds[1] == 0)
            {
                distance = (thresholds[1] - rotation.z + 360) % 360;
                if (distance <= (thresholds[1] - thresholds[0] + 360) % 360 && spinerotation.x >= thr.thresholds["StandingSpine"][0] && spinerotation.x <= thr.thresholds["StandingSpine"][1])
                {
                    distancel = Mathf.InverseLerp(0f, (thresholds[1] - thresholds[0] + 360) % 360, distance);
                    Activate(1 - distancel, muscle);

                }
                else
                {
                    Activate(0, muscle);
                }
            }
            else if (thresholds[1] == 265)
            {
                distance = rotation.y - thresholds[1];
                //print("distance looooool:  " + distance);
                if (hiprotation.x <= thr.thresholds["LyingSupine"][1] && hiprotation.x >= thr.thresholds["LyingSupine"][0])
                {
                    if (distance <= thresholds[0] - thresholds[1] && distance >= 0)
                    {
                        distancel = Mathf.InverseLerp(0f, thresholds[0] - thresholds[1], distance);
                        //Debug.Log("Distance 0-1 of joint CHEST: " + distancel);
                        Activate(1 - distancel, muscle2);
                    }
                    else
                    {
                        Activate(0, muscle2);
                    }

                }
                else
                {
                    Activate(0, muscle2);
                }
            }


        }
    }

    private void HandleArm2(GameObject joint, float[] thresholds) //90-115 310 265
    {
        string jname, jname2;
        GameObject muscle, muscle2, muscle3, muscle11, muscle12, muscle13;
        bool isLeft = false;
        float distance, distancel;
        muscle3 = GameObject.Find("Back2");
        //muscle11 = GameObject.Find("ShouldersM");
        //muscle12 = GameObject.Find("ChestM");
        //muscle13 = GameObject.Find("BackM");

        if (joint.name == "OneSkeleton_LeftArm2")
        {
            jname = "LArm2";
            jname2 = "LForeArm2";
            isLeft = true;
            muscle = GameObject.Find("LShoulder2");
            muscle2 = GameObject.Find("LChest2");
            isActivated2 = isActivatedL2;
        }
        else
        {
            jname = "RArm2";
            jname2 = "RForeArm2";
            muscle = GameObject.Find("RShoulder2");
            muscle2 = GameObject.Find("RChest2");
            isActivated2 = isActivatedR2;
        }

        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 rotation2 = b.bodyparts[jname2].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips2"].transform.localRotation.eulerAngles;
        Vector3 spinerotation = b.bodyparts["Spine21"].transform.localRotation.eulerAngles;

        if ((thresholds[1] > thresholds[0] || thresholds[1] == 275) && rotation.z > 280 && rotation.z < 290)
        {
            if (thresholds[1] < 275)
            {
                distance = thresholds[1] - rotation.x;
                if (distance <= thresholds[1] - thresholds[0] && distance >= 0) //rotation2.z >= thr.thresholds["Bicep"][1] && rotation2.z <= thr.thresholds["Bicep"][0]
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
                distance = rotation.x - thresholds[1];

                if (distance <= thresholds[0] - thresholds[1] && distance >= 0)
                {

                    distancel = Mathf.InverseLerp(0f, thresholds[0] - thresholds[1], distance);
                    //print("Distance 0-1 of joint " + jname + ": " + distancel);
                    Activate(1 - distancel, muscle);
                    if (isLeft) isActivatedL2 = true;
                    else isActivatedR2 = true;
                }
                else
                {
                    if (isLeft) isActivatedL2 = false;
                    else isActivatedR2 = false;
                    Activate(0, muscle);
                }
            }
        }
        else
        {
            if (thresholds[1] == 0)
            {
                distance = (thresholds[1] - rotation.z + 360) % 360;
                if (distance <= (thresholds[1] - thresholds[0] + 360) % 360 && spinerotation.x >= thr.thresholds["StandingSpine"][0] && spinerotation.x <= thr.thresholds["StandingSpine"][1])
                {
                    distancel = Mathf.InverseLerp(0f, (thresholds[1] - thresholds[0] + 360) % 360, distance);
                    Activate(1 - distancel, muscle);
                }
                else
                {
                    Activate(0, muscle);
                }
            }
            else if (thresholds[1] == 265)
            {
                distance = rotation.y - thresholds[1];
                //print("distance looooool:  " + distance);
                if (hiprotation.x <= thr.thresholds["LyingSupine"][1] && hiprotation.x >= thr.thresholds["LyingSupine"][0])
                {
                    if (distance <= thresholds[0] - thresholds[1] && distance >= 0)
                    {
                        distancel = Mathf.InverseLerp(0f, thresholds[0] - thresholds[1], distance);
                        //Debug.Log("Distance 0-1 of joint CHEST: " + distancel);
                        Activate(1 - distancel, muscle2);
                    }
                    else
                    {
                        Activate(0, muscle2);
                    }

                }
                else
                {
                    Activate(0, muscle2);
                }
            }


        }
    }

    private void HandleForeArm(GameObject joint, float[] thresholds)
    {
        string jname, jname2;
        float distance, distancel, distance2, d2;
        GameObject muscle;
        bool isLeft = false;
        if (joint.name == "OneSkeleton_LeftForeArm")
        {
            jname = "LForeArm";
            jname2 = "LArm";
            isLeft = true;
        }
        else
        {
            jname = "RForeArm";
            jname2 = "RArm";
        }
        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 rotation2 = b.bodyparts[jname2].transform.localRotation.eulerAngles;
        Vector3 spinerotation = b.bodyparts["Spine"].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;
        distance = thresholds[1] - rotation.y;
        distance2 = (thresholds[1] - rotation.y + 360) % 360;
        d2 = (thresholds[1] - thresholds[0] + 360) % 360;
        if (thresholds[1] < 35)
        {
            if (isLeft) muscle = GameObject.Find("LTricep");
            else muscle = GameObject.Find("RTricep");

            if (hiprotation.x >= thr.thresholds["StandingHip"][0] || hiprotation.x <= thr.thresholds["StandingHip"][1])
            {

                if (distance2 <= d2)
                {
                    if (spinerotation.x <= thr.thresholds["Benting"][1] && spinerotation.x >= thr.thresholds["Benting"][0])
                    {
                        if (!isBenting)
                        {
                            print("IS BENTING NOW");
                            isBenting = true;
                        }
                        //print("Distance of joint " + jname + ": " + distance);
                        distancel = Mathf.InverseLerp(0f, d2, distance2);
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
                else
                {
                    Activate(0, muscle);
                }
            }
            else
            {
                Activate(0, muscle);
            }
        }
        else
        {
            if (isLeft) muscle = GameObject.Find("LBicep");
            else muscle = GameObject.Find("RBicep");

            if (distance > thresholds[1] - thresholds[0] && distance <= 0 && rotation2.z <= thr.thresholds["Shoulder1"][0])
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
            else
            {
                Activate(0, muscle);
            }
        }
    }

    private void HandleForeArm2(GameObject joint, float[] thresholds)
    {
        string jname, jname2;
        float distance, distancel, distance2, d2;
        GameObject muscle;
        bool isLeft = false;
        if (joint.name == "OneSkeleton_LeftForeArm2")
        {
            jname = "LForeArm2";
            jname2 = "LArm2";
            isLeft = true;
        }
        else
        {
            jname = "RForeArm2";
            jname2 = "RArm2";
        }
        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 rotation2 = b.bodyparts[jname2].transform.localRotation.eulerAngles;
        Vector3 spinerotation = b.bodyparts["Spine21"].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips2"].transform.localRotation.eulerAngles;
        distance = thresholds[1] - rotation.y;
        distance2 = (thresholds[1] - rotation.y + 360) % 360;
        d2 = (thresholds[1] - thresholds[0] + 360) % 360;
        if (thresholds[1] < 35)
        {
            if (isLeft) muscle = GameObject.Find("LTricep2");
            else muscle = GameObject.Find("RTricep2");

            if (hiprotation.x >= thr.thresholds["StandingHip"][0] || hiprotation.x <= thr.thresholds["StandingHip"][1])
            {

                if (distance2 <= d2)
                {
                    if (spinerotation.x <= thr.thresholds["Benting"][1] && spinerotation.x >= thr.thresholds["Benting"][0])
                    {
                        if (!isBenting2)
                        {
                            print("IS BENTING NOW");
                            isBenting2 = true;
                        }
                        //print("Distance of joint " + jname + ": " + distance);
                        distancel = Mathf.InverseLerp(0f, d2, distance2);
                        //print("Distance 0-1 of joint " + jname + ": " + distancel);
                        Activate(1 - distancel, muscle);
                    }
                    else
                    {
                        if (isBenting2)
                        {
                            print("ISN'T BENTING ANYMORE");
                            isBenting2 = false;
                        }
                        Activate(0, muscle);
                    }
                }
                else
                {
                    Activate(0, muscle);
                }
            }
            else
            {
                Activate(0, muscle);
            }
        }
        else
        {
            if (isLeft) muscle = GameObject.Find("LBicep2");
            else muscle = GameObject.Find("RBicep2");

            if (distance > thresholds[1] - thresholds[0] && distance <= 0 && rotation2.z <= thr.thresholds["Shoulder1"][0])
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
            else
            {
                Activate(0, muscle);
            }
        }
    }


    private void HandleUpLeg(GameObject joint, float[] thresholds)
    {

    }

    private void HandleUpLeg2(GameObject joint, float[] thresholds)
    {

    }

    private void HandleLeg(GameObject joint, float[] thresholds)
    {
        string jname;
        float distance, distancel, d1;
        GameObject muscle;
        bool isLeft = false;

        if (joint.name == "OneSkeleton_LeftLeg")
        {
            jname = "LLeg";
            isLeft = true;
        }
        else jname = "RLeg";

        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;

        distance = (rotation.x - thresholds[1] + 360) % 360;
        d1 = (thr.thresholds["Quad"][0] - thr.thresholds["Quad"][1] + 360) % 360;

        if (isLeft) muscle = GameObject.Find("LQuad");
        else muscle = GameObject.Find("RQuad");

        if (distance <= d1 && thresholds[1] == thr.thresholds["Quad"][1])
        {
            if (hiprotation.x >= thr.thresholds["StandingHip"][0] || hiprotation.x <= thr.thresholds["StandingHip"][1])
            {

                if (distance != d1)
                {
                    //if(isSitting) more ROM
                    //if not:
                    //print("Distance of joint " + jname + ": " + distance);
                    distancel = Mathf.InverseLerp(0f, d1, distance);
                    //print("Distance 0-1 of joint " + jname + ": " + distancel);
                    Activate(1 - distancel, muscle);
                }
                else
                {
                    Activate(0, muscle);
                }
            }
            else
            {
                Activate(0, muscle);
            }
        }

        else if (thresholds[1] == thr.thresholds["Quad"][1]) Activate(0, muscle);

        else
        {
            if (isLeft) muscle = GameObject.Find("LHamstring");
            else muscle = GameObject.Find("RHamstring");

            distance = thresholds[1] - rotation.x;
            if (distance <= thresholds[1] - thresholds[0] && distance >= 0)
            {
                //Debug.Log("Distance of joint " + jname + ": " + distance);
                distancel = Mathf.InverseLerp(thresholds[1] - thresholds[0], 0f, distance);
                //Debug.Log("Distance 0-1 of joint " + jname + ": " + distancel);
                Activate(distancel, muscle);
            }
            else
            {
                Activate(0, muscle);
            }
        }
    }

    private void HandleLeg2(GameObject joint, float[] thresholds)
    {
        string jname;
        float distance, distancel, d1;
        GameObject muscle;
        bool isLeft = false;

        if (joint.name == "OneSkeleton_LeftLeg2")
        {
            jname = "LLeg2";
            isLeft = true;
        }
        else jname = "RLeg2";

        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips2"].transform.localRotation.eulerAngles;

        distance = (rotation.x - thresholds[1] + 360) % 360;
        d1 = (thr.thresholds["Quad"][0] - thr.thresholds["Quad"][1] + 360) % 360;

        if (isLeft) muscle = GameObject.Find("LQuad2");
        else muscle = GameObject.Find("RQuad2");

        if (distance <= d1 && thresholds[1] == thr.thresholds["Quad"][1])
        {
            if (hiprotation.x >= thr.thresholds["StandingHip"][0] || hiprotation.x <= thr.thresholds["StandingHip"][1])
            {

                if (distance != d1)
                {
                    //if(isSitting) more ROM
                    //if not:
                    //print("Distance of joint " + jname + ": " + distance);
                    distancel = Mathf.InverseLerp(0f, d1, distance);
                    //print("Distance 0-1 of joint " + jname + ": " + distancel);
                    Activate(1 - distancel, muscle);
                }
                else
                {
                    Activate(0, muscle);
                }
            }
            else
            {
                Activate(0, muscle);
            }
        }

        else if (thresholds[1] == thr.thresholds["Quad"][1]) Activate(0, muscle);

        else
        {
            if (isLeft) muscle = GameObject.Find("LHamstring2");
            else muscle = GameObject.Find("RHamstring2");

            distance = thresholds[1] - rotation.x;
            if (distance <= thresholds[1] - thresholds[0] && distance >= 0)
            {
                //Debug.Log("Distance of joint " + jname + ": " + distance);
                distancel = Mathf.InverseLerp(thresholds[1] - thresholds[0], 0f, distance);
                //Debug.Log("Distance 0-1 of joint " + jname + ": " + distancel);
                Activate(distancel, muscle);
            }
            else
            {
                Activate(0, muscle);
            }
        }
    }

    private void HandleFoot(GameObject joint, float[] thresholds)
    {
        string jname;
        float distance, distancel;
        GameObject muscle;
        bool isLeft = false;
        if (joint.name == "OneSkeleton_LeftFoot")
        {
            jname = "LFoot";
            isLeft = true;
        }
        else jname = "RFoot";

        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;

        distance = thresholds[1] - rotation.x;
        if (isLeft) muscle = GameObject.Find("LCalf");
        else muscle = GameObject.Find("RCalf");

        if (distance < thresholds[1] - thresholds[0] && distance >= 0)
        {
            if (hiprotation.x >= thr.thresholds["StandingHip"][0] || hiprotation.x <= thr.thresholds["StandingHip"][1])
            {
                //Debug.Log("Distance of joint " + jname + ": " + distance);
                distancel = Mathf.InverseLerp(0f, thresholds[1] - thresholds[0], distance);
                //Debug.Log("Distance 0-1 of joint " + jname + ": " + distancel);
                Activate(1 - distancel, muscle);
            }
        }
        else
        {
            Activate(0, muscle);
        }
    }

    private void HandleFoot2(GameObject joint, float[] thresholds)
    {
        string jname;
        float distance, distancel;
        GameObject muscle;
        bool isLeft = false;
        if (joint.name == "OneSkeleton_LeftFoot2")
        {
            jname = "LFoot2";
            isLeft = true;
        }
        else jname = "RFoot2";

        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips2"].transform.localRotation.eulerAngles;

        distance = thresholds[1] - rotation.x;
        if (isLeft) muscle = GameObject.Find("LCalf2");
        else muscle = GameObject.Find("RCalf2");

        if (distance < thresholds[1] - thresholds[0] && distance >= 0)
        {
            if (hiprotation.x >= thr.thresholds["StandingHip"][0] || hiprotation.x <= thr.thresholds["StandingHip"][1])
            {
                //Debug.Log("Distance of joint " + jname + ": " + distance);
                distancel = Mathf.InverseLerp(0f, thresholds[1] - thresholds[0], distance);
                //Debug.Log("Distance 0-1 of joint " + jname + ": " + distancel);
                Activate(1 - distancel, muscle);
            }
        }
        else
        {
            Activate(0, muscle);
        }
    }


    private void HandleCore(GameObject joint, float[] thresholds)
    {
        float distance, distancel;
        GameObject muscle;

        Vector3 rotation = b.bodyparts["Spine"].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;
        distance = thresholds[1] - rotation.x;
        //print("THresholds: " + thresholds[0] + " " + thresholds[1]);
        //print("Distance of joint: " + distance);
        if (thresholds[1] < thresholds[0])
        {
            muscle = GameObject.Find("Dorsals");
            if (distance >= thresholds[1] - thresholds[0] && rotation.x >= thr.thresholds["Arching"][1])
            {
                if (hiprotation.x <= thr.thresholds["LyingProne"][1] && hiprotation.x >= thr.thresholds["LyingProne"][0])
                {
                    if (!isLyingProne)
                    {
                        print("IS LYING PRONE NOW");
                        isLyingProne = true;
                    }
                    //print("Distance of joint " + jname + ": " + distance);
                    distancel = Mathf.InverseLerp(thresholds[1] - thresholds[0], 0f, distance);
                    //print("Distance 0-1 of joint " + jname + ": " + distancel);

                    Activate(distancel, muscle);
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
            else
            {
                Activate(0, muscle);
            }
        }
        else
        {
            muscle = GameObject.Find("Abs");
            if (distance <= thresholds[1] - thresholds[0] && rotation.x <= thr.thresholds["Abs"][1])
            {
                if (hiprotation.x <= thr.thresholds["LyingSupine"][1] && hiprotation.x >= thr.thresholds["LyingSupine"][0])
                {
                    if (!isLyingSupine) print("IS LYING SUPINE NOW");
                    isLyingSupine = true;
                    Debug.Log("Distance of joint Spine: " + distance);
                    distancel = Mathf.InverseLerp(0f, thresholds[1] - thresholds[0], distance);
                    Debug.Log("Distance 0-1 of joint Spine: " + distancel);
                    Activate(1 - distancel, muscle);
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
            else
            {
                Activate(0, muscle);
            }
        }
    }

    private void HandleCore2(GameObject joint, float[] thresholds)
    {
        float distance, distancel;
        GameObject muscle;

        Vector3 rotation = b.bodyparts["Spine21"].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;
        distance = thresholds[1] - rotation.x;
        //print("THresholds: " + thresholds[0] + " " + thresholds[1]);
        //print("Distance of joint: " + distance);
        if (thresholds[1] < thresholds[0])
        {
            muscle = GameObject.Find("Dorsals2");
            if (distance >= thresholds[1] - thresholds[0] && rotation.x >= thr.thresholds["Arching"][1])
            {
                if (hiprotation.x <= thr.thresholds["LyingProne"][1] && hiprotation.x >= thr.thresholds["LyingProne"][0])
                {
                    if (!isLyingProne2)
                    {
                        print("IS LYING PRONE NOW");
                        isLyingProne2 = true;
                    }
                    //print("Distance of joint " + jname + ": " + distance);
                    distancel = Mathf.InverseLerp(thresholds[1] - thresholds[0], 0f, distance);
                    //print("Distance 0-1 of joint " + jname + ": " + distancel);

                    Activate(distancel, muscle);
                }
                else
                {
                    if (!isLyingProne2)
                    {
                        print("ISN'T LYING PRONE ANYMORE");
                        isLyingProne2 = false;
                    }
                    Activate(0, muscle);
                }
            }
            else
            {
                Activate(0, muscle);
            }
        }
        else
        {
            muscle = GameObject.Find("Abs2");
            if (distance <= thresholds[1] - thresholds[0] && rotation.x <= thr.thresholds["Abs"][1])
            {
                if (hiprotation.x <= thr.thresholds["LyingSupine"][1] && hiprotation.x >= thr.thresholds["LyingSupine"][0])
                {
                    if (!isLyingSupine2) print("IS LYING SUPINE NOW");
                    isLyingSupine2 = true;
                    Debug.Log("Distance of joint Spine: " + distance);
                    distancel = Mathf.InverseLerp(0f, thresholds[1] - thresholds[0], distance);
                    Debug.Log("Distance 0-1 of joint Spine: " + distancel);
                    Activate(1 - distancel, muscle);
                }
                else
                {
                    if (!isLyingSupine2)
                    {
                        print("ISN'T LYING SUPINE ANYMORE");
                        isLyingSupine2 = false;
                    }
                    Activate(0, muscle);
                }
            }
            else
            {
                Activate(0, muscle);
            }
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

    Color DarkenColor(Color originalColor, float factor)
    {
        // Clamp the factor between 0 and 1
        factor = Mathf.Clamp01(factor);

        // Darken the color by reducing the red and green components
        float newRed = originalColor.r * (1 - factor);
        float newGreen = originalColor.g * (1 - factor);

        // Keep the blue and alpha components unchanged
        float newBlue = originalColor.b;
        float newAlpha = originalColor.a;

        // Return the new color
        return new Color(newRed, newGreen, newBlue, newAlpha);
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
            Color darkerYellow = DarkenColor(Color.yellow, 0.5f);
            Color lerpedColor = Color.Lerp(darkerYellow, Color.red, intensity);
            //Debug.Log("Activated " + muscle.name + " with intensity " + intensity);
            m.color = lerpedColor;
            m.SetColor("_EmissionColor", lerpedColor);
            // If your material is using emission, you may need to enable it explicitly
            m.EnableKeyword("_EMISSION");
            // You might need to update the material to apply the changes
            m.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        }
        else if (intensity == 0)
        {
            m.color = Color.white;
            m.SetColor("_EmissionColor", Color.black);
            // If your material is using emission, you may need to enable it explicitly
            m.EnableKeyword("_EMISSION");
            // You might need to update the material to apply the changes
            m.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        }
        if (transform.childCount != 0)
        {
            foreach (SkinnedMeshRenderer renderer in muscle.transform.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                Material m1 = renderer.material;
                if (intensity > 0)
                {
                    Color darkerYellow = DarkenColor(Color.yellow, 0.5f);
                    Color lerpedColor = Color.Lerp(darkerYellow, Color.red, intensity);
                    //Debug.Log("Activated " + muscle.name + " with intensity " + intensity);
                    m1.color = lerpedColor;
                    m1.SetColor("_EmissionColor", lerpedColor);
                    // If your material is using emission, you may need to enable it explicitly
                    m1.EnableKeyword("_EMISSION");
                    // You might need to update the material to apply the changes
                    m1.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                }
                else if (intensity == 0)
                {
                    m1.color = Color.white;
                    m1.SetColor("_EmissionColor", Color.black);
                    // If your material is using emission, you may need to enable it explicitly
                    m1.EnableKeyword("_EMISSION");
                    // You might need to update the material to apply the changes
                    m1.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                }
            }
        }

    }


}

/*
 * private void HandleLeg(GameObject joint, float[] thresholds)
    {
        string jname;
        float distance, distancel, d1;
        GameObject muscle, muscle11 ;
        bool isLeft = false;

        if (joint.name == "OneSkeleton_LeftLeg")
        {
            jname = "LLeg";
            isLeft = true;
        }
        else jname = "RLeg";

        Vector3 rotation = b.bodyparts[jname].transform.localRotation.eulerAngles;
        Vector3 hiprotation = b.bodyparts["Hips"].transform.localRotation.eulerAngles;

        distance = (thresholds[1] - rotation.z + 360) % 360;
        d1 = (thr.thresholds["Quad"][1] - thr.thresholds["Quad"][0] + 360) % 360;

        muscle11= GameObject.Find("QuadsM");
        if (isLeft) muscle = GameObject.Find("LQuad");
        else muscle = GameObject.Find("RQuad");

        if (distance <= d1 && thresholds[1] == thr.thresholds["Quad"][1])
        {
            if (hiprotation.x >= thr.thresholds["StandingHip"][0] && hiprotation.x <= thr.thresholds["StandingHip"][1])
            {

                if (distance != d1)
                {
                    //if(isSitting) more ROM
                    //if not:
                    //print("Distance of joint " + jname + ": " + distance);
                    distancel = Mathf.InverseLerp(0f, (thresholds[1] - thresholds[0] + 360) % 360, distance);
                    //print("Distance 0-1 of joint " + jname + ": " + distancel);
                    Activate(1 - distancel, muscle);
                    Activate(1 - distancel, muscle11);
                }
                else
                {
                    Activate(0, muscle);
                    Activate(0, muscle11);
                }
            }
            else
            {
                Activate(0, muscle);
                Activate(0, muscle11);
            }
        }

        else if (thresholds[1] == thr.thresholds["Quad"][1]) Activate(0, muscle);

        else
        {
            muscle11 = GameObject.Find("HamstringsM");
            if (isLeft) muscle = GameObject.Find("LHamstring");
            else muscle = GameObject.Find("RHamstring");

            distance = thresholds[1] - rotation.z;
            if (distance >= thresholds[1] - thresholds[0] && distance <= 0)
            {
                //Debug.Log("Distance of joint " + jname + ": " + distance);
                distancel = Mathf.InverseLerp(thresholds[1] - thresholds[0], 0f, distance);
                //Debug.Log("Distance 0-1 of joint " + jname + ": " + distancel);
                Activate(distancel, muscle);
                Activate(distancel, muscle11);
            }
            else if (distance > 0)
            {
                //Debug.Log("Distance of joint " + jname + ": " + distance);
                distancel = Mathf.InverseLerp(0f, thresholds[0] - thresholds[1], distance);
                //Debug.Log("Distance 0-1 of joint " + jname + ": " + distancel);
                Activate(1 - distancel, muscle);
                Activate(1 - distancel, muscle11);
            }
            else
            {
                Activate(0, muscle);
                Activate(0, muscle11);
            }
        }
    }
 */