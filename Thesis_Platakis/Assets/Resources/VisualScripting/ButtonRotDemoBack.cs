using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonRotDemoBack : MonoBehaviour
{
    GameObject btn;
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
        //demo animations
    }

    public void OnButtonClickBack()
    {
        //destroy and then reimport
        btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Rotate: No";
        GameObject.Find("MarmaRotate(Clone)").GetComponent<Animator>().enabled = false;

        GameObject.Find("CanvasButton").transform.GetChild(2).gameObject.SetActive(false);
        GameObject.Find("CanvasButton").transform.GetChild(1).gameObject.SetActive(true);

        //video screen restart

        GameObject.Find("CanvasExercises").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("CanvasExercises").transform.GetChild(1).gameObject.SetActive(true);



    }
}
