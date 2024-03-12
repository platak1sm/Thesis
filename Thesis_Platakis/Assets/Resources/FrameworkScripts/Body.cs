using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Dictionary<string, GameObject> bodyparts = new Dictionary<string, GameObject>();

    private void Awake()
    {
        bodyparts.Add("LShoulder", GameObject.Find("OneSkeleton_LeftShoulder"));
        bodyparts.Add("RShoulder", GameObject.Find("OneSkeleton_RightShoulder"));
        bodyparts.Add("LArm", GameObject.Find("OneSkeleton_LeftArm"));
        bodyparts.Add("RArm", GameObject.Find("OneSkeleton_RightArm"));
        bodyparts.Add("LForeArm", GameObject.Find("OneSkeleton_LeftForeArm"));
        bodyparts.Add("RForeArm", GameObject.Find("OneSkeleton_RightForeArm"));
        bodyparts.Add("LUpLeg", GameObject.Find("OneSkeleton_LeftUpLeg"));
        bodyparts.Add("RUpLeg", GameObject.Find("OneSkeleton_RightUpLeg"));
        bodyparts.Add("LLeg", GameObject.Find("OneSkeleton_LeftLeg"));
        bodyparts.Add("RLeg", GameObject.Find("OneSkeleton_RightLeg"));
        bodyparts.Add("LFoot", GameObject.Find("OneSkeleton_LeftFoot"));
        bodyparts.Add("RFoot", GameObject.Find("OneSkeleton_RightFoot"));
        bodyparts.Add("Spine", GameObject.Find("OneSkeleton_Spine"));
        bodyparts.Add("Spine1", GameObject.Find("OneSkeleton_Spine1"));
        bodyparts.Add("Spine2", GameObject.Find("OneSkeleton_Spine2"));
        bodyparts.Add("Hips", GameObject.Find("OneSkeleton_Hips1"));
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
