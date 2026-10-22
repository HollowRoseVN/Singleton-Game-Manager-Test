using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class MyGameEventMan : MonoBehaviour
{

    public int buttonPressCount;
    public int minimumButtonsToPress = 0;
    public int maximumButtonsToPress = 11;
    public PastryScript Pastry;
    public GreensScript Greens;
    public Button Eventbutton_yum;
    public Button Eventbutton_yum1;
    public Button Eventbutton_yuck;
    public Button RestartButton;
    public TMP_Text ScoreFeedback;
    public TMP_Text CounterText;

    [Header("Messages")]
    public string fullOfSweetsMessage = "Yay! I'm full of sweets!";
    public string tooFullForSweetsMessage = "I'm too full for sweets...";
    public string restartMessage = "Let me at 'em.";

    private int startingScore;
    private bool gameOver;

    // Start is called before the first frame update


    void Awake()
    {
        if (Eventbutton_yum == null || Eventbutton_yuck == null || CounterText == null
            || Pastry == null || Greens == null)
        {
            Debug.LogError("MyGameEventMan: assign all fields in the Inspector.", this);
            return;
        }

        startingScore = buttonPressCount;
        RestartButton.gameObject.SetActive(false);
        CounterText.text = $"Score: {buttonPressCount}";
    }

    //*** On Enable happens when the gameobject is enabled
    void OnEnable()
    { Debug.Log("EventManagerEnabled");

        if (Eventbutton_yum == null || Eventbutton_yuck == null || Eventbutton_yum1 == null || RestartButton == null) return;
        //** Declare events and addevent listeners to inform when button press has occured
        Eventbutton_yum.onClick.AddListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_yum1.onClick.AddListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_yuck.onClick.AddListener(DecrementAndEvaluateButtonPressCount);
        RestartButton.onClick.AddListener(RestartGame);
    }

    //*** On Disable happens when the gameobject is enabled
    void OnDisable()
    { Debug.Log("EventManagerDisabled");

        if (Eventbutton_yum == null || Eventbutton_yuck == null || Eventbutton_yum1 == null || RestartButton == null) return;
        //** Remove events and addevent listeners to inform when button press has occured
        //*** We do this to keep from  events being double registered or registring in
        // scripts that the engine has destroyed
        Eventbutton_yum.onClick.RemoveListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_yum1.onClick.RemoveListener(IncrementAndEvaluateButtonPressCount);
        Eventbutton_yuck.onClick.RemoveListener(DecrementAndEvaluateButtonPressCount);
        RestartButton.onClick.RemoveListener(RestartGame);
    }
    
    void IncrementAndEvaluateButtonPressCount()
    { Debug.Log ("pressbutton!");

        buttonPressCount = buttonPressCount + 1;
        Debug.Log(" Buttons pressed == " + buttonPressCount.ToString());

        // if (buttonPressCount >= maximumButtonsToPress)
            // Debug.Log(" Pressed All Available buttons!");

        if (gameOver) return;

        if (buttonPressCount > maximumButtonsToPress)
         {
            buttonPressCount = maximumButtonsToPress;
         }

        Debug.Log("Score == " + buttonPressCount);

        Pastry.IncrementAndEvaluatePastryButtonPressCount();
        CounterText.text = $"Score: {buttonPressCount}";

        if (buttonPressCount >= maximumButtonsToPress)
        {
         EndGame(fullOfSweetsMessage);
        }
    }

    void DecrementAndEvaluateButtonPressCount()
    { Debug.Log ("pressbutton!");

        buttonPressCount = buttonPressCount - 1;
        Debug.Log(" Buttons pressed == " + buttonPressCount.ToString());
        
        if (gameOver) return;

        if (buttonPressCount < minimumButtonsToPress)
        {
            buttonPressCount = minimumButtonsToPress;
        }

        Debug.Log("Score == " + buttonPressCount);

        Greens.DecrementAndEvaluateButtonPressCount();
        CounterText.text = $"Score: {buttonPressCount}";    // same lines again
       
        if (buttonPressCount <= minimumButtonsToPress)
         {
            EndGame(tooFullForSweetsMessage);
         }
    }


void EndGame(string message)
{
    gameOver = true;
    ScoreFeedback.text = message;           // overrides the "Yum!"/"Yuck!" text set a moment ago

    Eventbutton_yum.interactable = false;
    Eventbutton_yum1.interactable = false;
    Eventbutton_yuck.interactable = false;
    RestartButton.gameObject.SetActive(true);
}

void RestartGame()
{
    gameOver = false;
    buttonPressCount = startingScore;

    Pastry.ResetCount();
    Greens.ResetCount();

    UpdateCounter();
    ScoreFeedback.text = restartMessage;

    Eventbutton_yum.interactable = true;
    Eventbutton_yum1.interactable = true;
    Eventbutton_yuck.interactable = true;
    RestartButton.gameObject.SetActive(false);
}

void UpdateCounter()
{
    CounterText.text = $"Score: {buttonPressCount}";
}

//Reset function to simplify in place of restart

}       