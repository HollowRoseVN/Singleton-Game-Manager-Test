using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{

    public int buttonPressCount;
    public int maximumButtonsToPress;

    public GameEventButton eventbutton_1;
    public GameEventButton eventbutton_2;
    public GameEventButton eventbutton_3;
    public GameEventButton eventbutton_4;
    public GameEventButton eventbutton_5;

    // Start is called before the first frame update

    //*** On Enable happens when the gameobject is enabled
    void OnEnable()
    {

        //** Declare events and addevent listeners to inform when button press has occured
        eventbutton_1.OnButtonPress.AddListener(IncrementAndEvaluateButtonPressCount);
        eventbutton_2.OnButtonPress.AddListener(IncrementAndEvaluateButtonPressCount);
        eventbutton_3.OnButtonPress.AddListener(IncrementAndEvaluateButtonPressCount);
        eventbutton_4.OnButtonPress.AddListener(IncrementAndEvaluateButtonPressCount);
        eventbutton_5.OnButtonPress.AddListener(IncrementAndEvaluateButtonPressCount);
    }

    //*** On Disable happens when the gameobject is enabled
    void OnDisable()
    {
        //** Remove events and addevent listeners to inform when button press has occured
        //*** We do this to keep from  events being double registered or registring in
        // scripts that the engine has destroyed
        eventbutton_1.OnButtonPress.RemoveListener(IncrementAndEvaluateButtonPressCount);
        eventbutton_2.OnButtonPress.RemoveListener(IncrementAndEvaluateButtonPressCount);
        eventbutton_3.OnButtonPress.RemoveListener(IncrementAndEvaluateButtonPressCount);
        eventbutton_4.OnButtonPress.RemoveListener(IncrementAndEvaluateButtonPressCount);
        eventbutton_5.OnButtonPress.RemoveListener(IncrementAndEvaluateButtonPressCount);
    }
    
    void IncrementAndEvaluateButtonPressCount()
    {
        buttonPressCount = buttonPressCount + 1;
        Debug.Log(" Buttons pressed == " + buttonPressCount.ToString());

        if (buttonPressCount >= maximumButtonsToPress)
            Debug.Log(" Pressed All Available buttons!");

    }
}
