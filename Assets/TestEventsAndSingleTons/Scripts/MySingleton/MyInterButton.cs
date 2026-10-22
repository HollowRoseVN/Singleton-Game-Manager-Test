using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyInterButton : MonoBehaviour
{

    public bool wasPressed = false;
    public TMP_Text Feedback;

    [HeaderAttribute("AudioManager")]
    public GameObject EatSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PressButton()
    {

        if(wasPressed == false)
        {
            Debug.Log("New Button Pressed , incrementing count ! button name: " + this.gameObject.name );

            wasPressed = true;

            MyGameController.instance.ButtonPressedIncrementCount();

        }
        else
        {
            Debug.Log("This button was already pressed , not incrementing count");
            if (Feedback != null)
            {
                Feedback.text = "I already ate that. I want something different!";
            }
            else
            {
                Debug.LogError("Feedback is empty on " + gameObject.name, this);
            }

        }

    }
}

