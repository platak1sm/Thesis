using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Dictionary<string, GameObject> bodyparts = new Dictionary<string, GameObject>();
    private void Awake()
    {
        bodyparts.Add("LShoulder", GameObject.Find("Skeleton_LeftShoulder"));
        bodyparts.Add("RShoulder", GameObject.Find("Skeleton_RightShoulder"));
        bodyparts.Add("LArm", GameObject.Find("Skeleton_LeftArm"));
        bodyparts.Add("RArm", GameObject.Find("Skeleton_RightArm"));
        bodyparts.Add("LForeArm", GameObject.Find("Skeleton_LeftForeArm"));
        bodyparts.Add("RForeArm", GameObject.Find("Skeleton_RightForeArm"));
        bodyparts.Add("LUpLeg", GameObject.Find("Skeleton_LeftUpLeg"));
        bodyparts.Add("RUpLeg", GameObject.Find("Skeleton_RightUpLeg"));
        bodyparts.Add("LLeg", GameObject.Find("Skeleton_LeftLeg"));
        bodyparts.Add("RLeg", GameObject.Find("Skeleton_RightLeg"));
        bodyparts.Add("LFoot", GameObject.Find("Skeleton_LeftFoot"));
        bodyparts.Add("RFoot", GameObject.Find("Skeleton_RightFoot"));
        bodyparts.Add("Spine", GameObject.Find("Skeleton_Spine"));
        bodyparts.Add("Spine1", GameObject.Find("Skeleton_Spine1"));
        bodyparts.Add("Spine2", GameObject.Find("Skeleton_Spine2"));
        bodyparts.Add("Hips", GameObject.Find("Skeleton_Hips"));
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
