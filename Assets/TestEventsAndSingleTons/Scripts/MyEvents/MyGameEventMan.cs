using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameEventMan : MonoBehaviour
{

    public int buttonPressCount;
    public int maximumButtonsToPress;

    public Button Eventbutton_first;
    public Button Eventbutton_sec;
    public Button Eventbutton_thir;
    public Button Eventbutton_fou;
    public Button Eventbutton_fif;

    // Start is called before the first frame update

    //*** On Enable happens when the gameobject is enabled
    void OnEnable()
    { Debug.Log("EventManagerEnabled");

        //** Declare events and addevent listeners to inform when button press has occured
        Eventbutton_first.onClick.AddListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_sec.onClick.AddListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_thir.onClick.AddListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_fou.onClick.AddListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_fif.onClick.AddListener(IncrementAndEvaluateButtonPressCount);
    }

    //*** On Disable happens when the gameobject is enabled
    void OnDisable()
    { Debug.Log("EventManagerDisabled");
        //** Remove events and addevent listeners to inform when button press has occured
        //*** We do this to keep from  events being double registered or registring in
        // scripts that the engine has destroyed
        Eventbutton_first.onClick.RemoveListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_sec.onClick.RemoveListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_thir.onClick.RemoveListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_fou.onClick.RemoveListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_fif.onClick.RemoveListener(IncrementAndEvaluateButtonPressCount);
    }
    
    void IncrementAndEvaluateButtonPressCount()
    { Debug.Log ("pressbutton!");

        buttonPressCount = buttonPressCount + 1;
        Debug.Log(" Buttons pressed == " + buttonPressCount.ToString());

        if (buttonPressCount >= maximumButtonsToPress)
            Debug.Log(" Pressed All Available buttons!");

    }
}
