using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameController : MonoBehaviour
{

    public static MyGameController instance;

    public int buttonPressCount;
    public int maximumButtonsToPress;

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
    }
}
