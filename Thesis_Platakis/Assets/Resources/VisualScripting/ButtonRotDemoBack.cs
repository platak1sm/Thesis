using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MAGES.Utilities;

public class ButtonRotDemoBack : MonoBehaviour
{
    GameObject btn;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        btn = GameObject.Find("RotateButton");
    }

    public void OnButtonClickRot()
    {
        if (btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Contains("No"))
        {
            btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Rotate: Yes";
            GameObject.Find("MarmaRotate(Clone)").GetComponent<Animator>().enabled = true;
        }
        else
        {
            btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Rotate: No";
            GameObject.Find("MarmaRotate(Clone)").GetComponent<Animator>().enabled = false;
        }
    }

    public void OnButtonClickDemo()
    {
        animator = GameObject.Find("Marmarinio").GetComponent<Animator>();
        GameObject.Find("CanvasMuscles").SetActive(false);
        animator.Play("ShoulderDemo");
        GameObject.Find("CanvasButton").transform.GetChild(2).gameObject.SetActive(true);
        GameObject.Find("CanvasButton").transform.GetChild(1).gameObject.SetActive(false);
    }

    public void OnButtonClickBack()
    {
        animator = GameObject.Find("Marmarinio").GetComponent<Animator>();
        animator.StopPlayback();
        animator.Play("Initial");
        GameObject.Find("MarmaRotate(Clone)").transform.GetChild(1).gameObject.SetActive(true);
        btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Rotate: No";
        GameObject.Find("MarmaRotate(Clone)").GetComponent<Animator>().enabled = false;

        GameObject.Find("CanvasButton").transform.GetChild(2).gameObject.SetActive(false);
        GameObject.Find("CanvasButton").transform.GetChild(1).gameObject.SetActive(true);

        GameObject.Find("Screen").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("Screen").transform.GetChild(3).gameObject.SetActive(true);
        GameObject.Find("Screen").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Screen").transform.GetChild(4).gameObject.SetActive(false);
        GameObject.Find("Screen").transform.GetChild(5).gameObject.SetActive(false);

        GameObject.Find("CanvasExercises").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("CanvasExercises").transform.GetChild(1).gameObject.SetActive(true);



    }
}
