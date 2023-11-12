using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MuscleActivator : MonoBehaviour
{
    public GameObject model;

    private void Start()
    {
        
    }

    public abstract void Evaluate(GameObject[] joints, float[,] thresholds);

    public abstract void Activate();

    public abstract void Activate(float intensity, GameObject muscle);

    // Update is called once per frame
    void Update()
    {
        
    }
}
