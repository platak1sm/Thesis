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
        bodyparts.Add("LShoulder2", GameObject.Find("OneSkeleton_LeftShoulder2"));
        bodyparts.Add("RShoulder2", GameObject.Find("OneSkeleton_RightShoulder2"));
        bodyparts.Add("LArm2", GameObject.Find("OneSkeleton_LeftArm2"));
        bodyparts.Add("RArm2", GameObject.Find("OneSkeleton_RightArm2"));
        bodyparts.Add("LForeArm2", GameObject.Find("OneSkeleton_LeftForeArm2"));
        bodyparts.Add("RForeArm2", GameObject.Find("OneSkeleton_RightForeArm2"));
        bodyparts.Add("LUpLeg2", GameObject.Find("OneSkeleton_LeftUpLeg2"));
        bodyparts.Add("RUpLeg2", GameObject.Find("OneSkeleton_RightUpLeg2"));
        bodyparts.Add("LLeg2", GameObject.Find("OneSkeleton_LeftLeg2"));
        bodyparts.Add("RLeg2", GameObject.Find("OneSkeleton_RightLeg2"));
        bodyparts.Add("LFoot2", GameObject.Find("OneSkeleton_LeftFoot2"));
        bodyparts.Add("RFoot2", GameObject.Find("OneSkeleton_RightFoot2"));
        bodyparts.Add("Spine21", GameObject.Find("OneSkeleton_Spine2_1"));
        bodyparts.Add("Spine22", GameObject.Find("OneSkeleton_Spine2_2"));
        bodyparts.Add("Spine23", GameObject.Find("OneSkeleton_Spine2_3"));
        bodyparts.Add("Hips2", GameObject.Find("OneSkeleton_Hips2"));
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
