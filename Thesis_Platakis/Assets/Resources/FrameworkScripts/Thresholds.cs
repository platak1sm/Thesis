using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thresholds : MonoBehaviour
{
    public Dictionary<string, float[]> thresholds = new Dictionary<string, float[]>();
    private void Awake()
    {
        float[] t = new float[2];
        t[0] = 25f;
        t[1] = 90f;
        thresholds.Add("Shoulder1", t);
        float[] t1 = new float[2];
        t1[0] = 65f;
        t1[1] = 0f;
        thresholds.Add("Shoulder2", t1);
        float[] t2 = new float[2];
        t2[0] = 320f;
        t2[1] = 245f;
        thresholds.Add("Bicep", t2);
        float[] t3 = new float[2];
        t3[0] = 310f;
        t3[1] = 345f;
        thresholds.Add("Tricep", t3);
        float[] t4 = new float[2];
        t4[0] = 340f;
        t4[1] = 10f;
        thresholds.Add("Quad", t4);
        float[] t5 = new float[2];
        t5[0] = 310f;
        t5[1] = 245f;
        thresholds.Add("Hamstring", t5);
        float[] t6 = new float[2];
        t6[0] = 40f;
        t6[1] = 20f;
        thresholds.Add("Calf", t6);
        float[] t7 = new float[2];
        t7[0] = 360f;
        t7[1] = 290f;
        thresholds.Add("Abs", t7);
        float[] t8 = new float[2];
        t8[0] = 15f;
        t8[1] = 45f;
        thresholds.Add("Dorsal", t8);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

