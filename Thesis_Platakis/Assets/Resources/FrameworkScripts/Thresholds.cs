using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thresholds : MonoBehaviour
{
    public Dictionary<string, float[]> thresholds = new Dictionary<string, float[]>();


    private void Awake()
    {
        AddMovement(295f, 0f, "Shoulder1");      //Arm Joints
        AddMovement(340f, 275f, "Shoulder2");    //Arm Joints
        AddMovement(335f, 265f, "Chest");        //Arm Joints
        AddMovement(3f, 27f, "Back");            //Arm Joints
        AddMovement(345f, 285f, "Bicep");        //ForeArm Joints
        AddMovement(330f, 30f, "Tricep");        //ForeArm Joints
        AddMovement(3f, 325f, "Quad");           //Leg Joints
        AddMovement(10f, 90f, "Hamstring");      //Leg Joints
        AddMovement(7f, 37f, "Calf");            //Foot Joints 
        AddMovement(1f, 45f, "Abs");             //Spine Joint 
        AddMovement(359f, 320f, "Dorsal");       //Spine Joint
        AddMovement(10f, 45f, "Benting");        //Spine Joint 
        AddMovement(359f, 320f, "Arching");      //Spine Joint
        AddMovement(0f, 11f, "StandingSpine");   //Spine Joint
        AddMovement(348f, 10f, "StandingHip");   //Hip Joint
        AddMovement(270f, 300f, "LyingSupine");  //Hip Joint
        AddMovement(75f, 89f, "LyingProne");     //Hip Joint


    void AddMovement(float min, float max, string muscle)
    {
        float[] t = new float[2];
        t[0] = min;
        t[1] = max;
        thresholds.Add(muscle, t);
    }
}

