using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameEventMan : MonoBehaviour
{

    public int buttonPressCount;
    public int maximumButtonsToPress;

    public GameButton Eventbutton_first;
    public GameButton Eventbutton_sec;
    public GameButton Eventbutton_thir;
    public GameButton Eventbutton_fou;
    public GameButton Eventbutton_fif;

    // Start is called before the first frame update

    //*** On Enable happens when the gameobject is enabled
    void OnEnable()
    {

        //** Declare events and addevent listeners to inform when button press has occured
        Eventbutton_first.OnButtonPress.AddListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_sec.OnButtonPress.AddListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_thir.OnButtonPress.AddListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_fou.OnButtonPress.AddListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_fif.OnButtonPress.AddListener(IncrementAndEvaluateButtonPressCount);
    }

    //*** On Disable happens when the gameobject is enabled
    void OnDisable()
    {
        //** Remove events and addevent listeners to inform when button press has occured
        //*** We do this to keep from  events being double registered or registring in
        // scripts that the engine has destroyed
        Eventbutton_first.OnButtonPress.RemoveListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_sec.OnButtonPress.RemoveListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_thir.OnButtonPress.RemoveListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_fou.OnButtonPress.RemoveListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_fif.OnButtonPress.RemoveListener(IncrementAndEvaluateButtonPressCount);
    }
    
    void IncrementAndEvaluateButtonPressCount()
    {
        buttonPressCount = buttonPressCount + 1;
        Debug.Log(" Buttons pressed == " + buttonPressCount.ToString());

        if (buttonPressCount >= maximumButtonsToPress)
            Debug.Log(" Pressed All Available buttons!");

    }
}
