using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using MAGES.GameController;



public class HandPoseAnimator : MonoBehaviour
{
    public Animator handAnimator;
    public string whichHand = "";

    // Update is called once per frame
    void Update()
    {
        if (whichHand.Contains("Left"))
        {
            handAnimator.SetFloat("Grip_" + whichHand, MAGESControllerClass.Get.GetControllerGrabStrength(MAGESControllerClass.MAGESHand.left));
            handAnimator.SetFloat("Trigger_" + whichHand, MAGESControllerClass.Get.GetTriggerStrength(MAGESControllerClass.MAGESHand.left));
        }
        else
        {
            handAnimator.SetFloat("Grip_" + whichHand, MAGESControllerClass.Get.GetControllerGrabStrength(MAGESControllerClass.MAGESHand.right));
            handAnimator.SetFloat("Trigger_" + whichHand, MAGESControllerClass.Get.GetTriggerStrength(MAGESControllerClass.MAGESHand.right));
        }
    }
}
