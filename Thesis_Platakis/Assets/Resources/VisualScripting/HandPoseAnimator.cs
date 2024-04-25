using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using MAGES.GameController;
using MAGES.UIManagement;

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
            if (MAGESControllerClass.DeviceController.GetButtonPressed(MAGESControllerClass.MAGESHand.right,
    MAGESControllerClass.MAGESControllerButtons.A))
            {
                InterfaceManagement.Get.InterfaceRaycastActivation(true);
            }
            if (MAGESControllerClass.DeviceController.GetButtonPressed(MAGESControllerClass.MAGESHand.right,
    MAGESControllerClass.MAGESControllerButtons.B))
            {
                InterfaceManagement.Get.InterfaceRaycastActivation(false);
            }

        }
    }
}
