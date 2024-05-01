using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEx : MonoBehaviour
{
    Animator animator;
    GameObject uiexdynamic;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Marmarinio").GetComponent<Animator>();

    }

    public void BicepCurls()
    {
        GameObject.Find("CanvasMuscles").SetActive(false);
        animator.Play("Bicep");

        //video add

        GameObject.Find("CanvasExercises").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("CanvasExercises").transform.GetChild(1).gameObject.SetActive(false);
        uiexdynamic = GameObject.Find("UI_Exercises").transform.GetChild(1).gameObject;
        uiexdynamic.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Bicep Curls";
        uiexdynamic.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Bicep curls are targeting the biceps brachii, the large muscle on the front of your upper arm. " +
            "\n\nInstructions:" +
            "\n\n1) Stand with feet shoulder-width apart. Hold the weights with palms facing forward, arms fully extended but not locked." +
            "\n\n2) Keep your elbows close to your torso and fixed in place. Movement should come from the elbow joint, not the shoulder." +
            "\n\n3) Slowly lift the weight by bending your elbows, ensuring your upper arms remain stationary. Bring the weights up near your shoulders." +
            "\n\n4) Lower the weights in a controlled manner" +
            "\n\n5) Inhale as you lower the weights, exhale as you lift them.\n";

        GameObject.Find("CanvasButton").transform.GetChild(2).gameObject.SetActive(true);
        GameObject.Find("CanvasButton").transform.GetChild(1).gameObject.SetActive(false);
    }

    public void ShoulderFlies()
    {
        GameObject.Find("CanvasMuscles").SetActive(false);
        animator.Play("Shoulder");

        //video add

        GameObject.Find("CanvasExercises").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("CanvasExercises").transform.GetChild(1).gameObject.SetActive(false);
        uiexdynamic = GameObject.Find("UI_Exercises").transform.GetChild(1).gameObject;
        uiexdynamic.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Shoulder Flies";
        uiexdynamic.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Shoulder flies are exercises designed to target the deltoid muscles." +
            "\n\nInstructions:" +
            "\n\n1) Stand with feet shoulder-width apart, holding dumbbells at your sides with palms facing inward." +
            "\n\n2) Keep a slight bend in your elbows to reduce stress on the joint." +
            "\n\n3) Lift your arms outward to the sides, leading with the elbows, until they are approximately parallel to the ground. Keep your wrists aligned with your elbows, without shrugging your shoulders." +
            "\n\n4) Slowly lower the arms back to the starting position, maintaining control.\n";

        GameObject.Find("CanvasButton").transform.GetChild(2).gameObject.SetActive(true);
        GameObject.Find("CanvasButton").transform.GetChild(1).gameObject.SetActive(false);
    }

    public void CalfRaises()
    {
        GameObject.Find("CanvasMuscles").SetActive(false);
        animator.Play("Calf");

        //video add

        GameObject.Find("CanvasExercises").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("CanvasExercises").transform.GetChild(1).gameObject.SetActive(false);
        uiexdynamic = GameObject.Find("UI_Exercises").transform.GetChild(1).gameObject;
        uiexdynamic.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Calf Raises";
        uiexdynamic.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Calf raises are exercises designed to target the muscles in your calves, primarily the gastrocnemius and soleus." +
            "\n\nInstructions:" +
            "\n\n1) Stand with feet shoulder-width apart. You can hold onto a stable surface for balance or use weights for added resistance." +
            "\n\n2) Keep your core engaged to maintain stability." +
            "\n\n3) Raise your heels off the ground, lifting onto your toes. Focus on keeping your body straight and avoid leaning forward or backward." +
            "\n\n4) Hold the top position for a brief moment to ensure maximum contraction." +
            "\n\n5) Slowly lower your heels back to the starting position. Allow them to come slightly lower than ground level if using an elevated surface for a deeper stretch.\n";

        GameObject.Find("CanvasButton").transform.GetChild(2).gameObject.SetActive(true);
        GameObject.Find("CanvasButton").transform.GetChild(1).gameObject.SetActive(false);
    }
}
