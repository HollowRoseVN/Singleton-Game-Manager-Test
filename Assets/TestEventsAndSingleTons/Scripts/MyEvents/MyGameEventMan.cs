using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class MyGameEventMan : MonoBehaviour
{

    public int buttonPressCount;
    public int maximumButtonsToPress;
    public PastryScript Pastry;
    public GreensScript Greens;
    public Button Eventbutton_yum;
    public Button Eventbutton_yuck;
   // public ScoreFeedback;
    //public Counter;

    // Start is called before the first frame update

    //*** On Enable happens when the gameobject is enabled
    void OnEnable()
    { Debug.Log("EventManagerEnabled");

        //** Declare events and addevent listeners to inform when button press has occured
        Eventbutton_yum.onClick.AddListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_yuck.onClick.AddListener(IncrementAndEvaluateButtonPressCount);
    }

    //*** On Disable happens when the gameobject is enabled
    void OnDisable()
    { Debug.Log("EventManagerDisabled");
        //** Remove events and addevent listeners to inform when button press has occured
        //*** We do this to keep from  events being double registered or registring in
        // scripts that the engine has destroyed
        Eventbutton_yum.onClick.RemoveListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_yuck.onClick.RemoveListener(IncrementAndEvaluateButtonPressCount);
    }
    
    void IncrementAndEvaluateButtonPressCount()
    { Debug.Log ("pressbutton!");

        buttonPressCount = buttonPressCount + 1;
        Debug.Log(" Buttons pressed == " + buttonPressCount.ToString());

        if (buttonPressCount >= maximumButtonsToPress)
            Debug.Log(" Pressed All Available buttons!");
        
            Pastry.IncrementAndEvaluatePastryButtonPressCount();

    }

    void DecrementAndEvaluateButtonPressCount()
    { Debug.Log ("pressbutton!");

        buttonPressCount = buttonPressCount - 1;
        Debug.Log(" Buttons pressed == " + buttonPressCount.ToString());

        if (buttonPressCount >= maximumButtonsToPress)
            Debug.Log(" Pressed All Available buttons!");
        
            Greens.IncrementAndEvaluateButtonPressCount();

    }   
    
}
