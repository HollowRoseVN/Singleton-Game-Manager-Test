using UnityEngine;
using TMPro;

public class GreensScript : MonoBehaviour
{
    public int buttonPressCount;
    public int maximumButtonsToPress;

    [HeaderAttribute("AudioManager")]
    public GameObject YuckSound;
    public TMP_Text ScoreFeedback;

    public void DecrementAndEvaluateButtonPressCount()
    {
        Debug.Log("pressGreensButton!");

        buttonPressCount = buttonPressCount - 1;
        Debug.Log("Greens buttons pressed == " + buttonPressCount);

        if (buttonPressCount >= maximumButtonsToPress)
        {
            Debug.Log("Pressed maximum greens buttons!");
            ScoreFeedback.text = "I'm full of greens...";
        }

        if (YuckSound != null)
        {
            YuckSound.SetActive(false);
            YuckSound.SetActive(true);
        }

        if (ScoreFeedback == null)
        {
            Debug.LogError("Please assign the ScoreFeedback text object to GreensScript!", this);
            return;
        }

        ScoreFeedback.text = "Yuck! Greens!";
    }

    public void ResetCount()
{
    buttonPressCount = 0;
}
}