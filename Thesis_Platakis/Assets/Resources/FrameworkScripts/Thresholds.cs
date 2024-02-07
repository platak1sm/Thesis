using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thresholds : MonoBehaviour
{
    public Dictionary<string, float[]> thresholds = new Dictionary<string, float[]>();

    /*Doc*/

    private void Awake()
    {
        AddMovement(25f, 90f, "Shoulder1");      //Arm Joints
        AddMovement(75f, 9f, "Shoulder2");       //Arm Joints
        AddMovement(75f, 9f, "Chest");          //Arm Joints
        AddMovement(90f, 115f, "Back");          //Arm Joints
        AddMovement(320f, 245f, "Bicep");        //ForeArm Joints
        AddMovement(320f, 345f, "Tricep");       //ForeArm Joints
        AddMovement(340f, 10f, "Quad");          //Leg Joints
        AddMovement(310f, 245f, "Hamstring");    //Leg Joints
        AddMovement(40f, 20f, "Calf");           //Foot Joints
        AddMovement(360f, 290f, "Abs");          //Spine Joint
        AddMovement(15f, 45f, "Dorsal");         //Spine Joint
        AddMovement(230f, 320f, "Benting");      //Spine Joint
        AddMovement(50f, 70f, "Arching");        //Spine Joint
        AddMovement(30f, 350f, "StandingSpine"); //Spine Joint
        AddMovement(245f, 265f, "StandingHip");  //Hip Joint
        AddMovement(340f, 360f, "LyingSupine");  //Hip Joint
        AddMovement(150f, 190f, "LyingProne");   //Hip Joint                                  
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void AddMovement(float min, float max, string muscle)
    {
        float[] t = new float[2];
        t[0] = min;
        t[1] = max;
        thresholds.Add(muscle, t);
    }
}

