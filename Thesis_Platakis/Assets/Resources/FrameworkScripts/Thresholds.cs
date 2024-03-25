using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thresholds : MonoBehaviour
{
    public Dictionary<string, float[]> thresholds = new Dictionary<string, float[]>();

    /*Doc*/

    private void Awake()
    {
        AddMovement(295f, 0f, "Shoulder1");      //Arm Joints 25f, 90f //z rotation
        AddMovement(340f, 275f, "Shoulder2");    //Arm Joints 75f, 9f //otan z 285, x rotation moving
        AddMovement(335f, 265f, "Chest");          //Arm Joints 75f, 9f //y
        AddMovement(3f, 27f, "Back");          //Arm  Joints 90f, 115f // otan z einai 285, x rotation
        AddMovement(345f, 285f, "Bicep");        //ForeArm Joints320f, 245f
        AddMovement(330f, 30f, "Tricep");       //ForeArm Joints 320f, 345f
        AddMovement(3f, 325f, "Quad");          //Leg Joints 340f, 10f <,>
        AddMovement(10f, 90f, "Hamstring");    //Leg Joints 310f, 245f
        AddMovement(7f, 37f, "Calf");           //Foot Joints 40f, 20f
        AddMovement(1f, 45f, "Abs");          //Spine Joint 360f, 290f
        AddMovement(359f, 320f, "Dorsal");         //Spine Joint15f, 45f
        AddMovement(10f, 45f, "Benting");      //Spine Joint 230f, 320f
        AddMovement(359f, 320f, "Arching");        //Spine Joint 0f, 11f
        AddMovement(0f, 11f, "StandingSpine"); //Spine Joint 30f, 350f
        AddMovement(348f, 10f, "StandingHip");  //Hip Joint 245f, 265f <,>
        AddMovement(270f, 300f, "LyingSupine");  //Hip Joint anaskela 340f, 360f
        AddMovement(75f, 89f, "LyingProne");     //Hip Joint broumita    150f, 190f                             
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

