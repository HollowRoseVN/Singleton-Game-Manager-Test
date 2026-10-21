using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class MyGameController : MonoBehaviour
{

    public static MyGameController instance;

    public int buttonPressCount;
    public int maximumButtonsToPress;

    //private int startingScore;
   // private bool gameOver;


    [HeaderAttribute("AudioManager")]
    public GameObject EatSound;
    
    public TMP_Text Feedback;
    public TMP_Text CounterText;

    [Header("Messages")]
    public string someSweets = "Ohoho, just a little treat!";
    public string manySweets = "Well, I AM feeling peckish...";
    public string maxSweets = "...medic...someone call a medic...";

    // Awake is the function called Earliest when a scene is first initialized
    void Awake()
    {
        //*** We initialize an instance of the game controller only if an instance doesn't exist already
        if (instance == null)
            instance = this;
    }

   public void ButtonPressedIncrementCount()
    {
        //*** We increment the button press count
        buttonPressCount = buttonPressCount + 1;
        Debug.Log(" Buttons pressed == " + buttonPressCount.ToString());

        //*** We check  if all buttons were pressed
        if (buttonPressCount >= maximumButtonsToPress)
            Debug.Log(" Pressed All Available buttons!");

        if (buttonPressCount >= 2)
        Feedback.text = "Ohoho, just a little treat!";

        if (buttonPressCount >= 3)
        Feedback.text = "Well, I AM feeling peckish...";

        if (buttonPressCount >= 4)
        Feedback.text = "...medic...someone call a medic...";

        CounterText.text = $"Score: {buttonPressCount}";

    }
    public void IncrementAndEvaluateButtonPressCount()
    { Debug.Log ("pressbutton!");

        buttonPressCount = buttonPressCount + 1;
        Debug.Log(" Buttons pressed == " + buttonPressCount.ToString());

        if (buttonPressCount >= maximumButtonsToPress)
            Debug.Log(" Pressed All Available buttons!");

    }

}


