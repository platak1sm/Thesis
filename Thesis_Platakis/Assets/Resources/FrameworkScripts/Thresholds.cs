using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thresholds : MonoBehaviour
{
    public Dictionary<string, float[]> thresholds = new Dictionary<string, float[]>();

    /*Doc*/

    private void Awake()
    {
        AddMovement(25f, 90f, "Shoulder1");
        AddMovement(65f, 0f, "Shoulder2");
        AddMovement(320f, 245f, "Bicep");
        AddMovement(310f, 345f, "Tricep");
        AddMovement(340f, 10f, "Quad");
        AddMovement(310f, 245f, "Hamstring");
        AddMovement(40f, 20f, "Calf");
        AddMovement(360f, 290f, "Abs");
        AddMovement(15f, 45f, "Dorsal");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

