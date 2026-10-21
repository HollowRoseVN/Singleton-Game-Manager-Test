using UnityEngine;
using TMPro;

public class PastryScript : MonoBehaviour
{

    public int pastryButtonPressCount;
    public int maximumButtonsToPress;

    [HeaderAttribute("AudioManager")]
    public GameObject YumSound;
    public TMP_Text ScoreFeedback;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

     public void IncrementAndEvaluatePastryButtonPressCount()
         { Debug.Log ("pressPastryButton!");

            pastryButtonPressCount = pastryButtonPressCount + 1;
            Debug.Log(" Buttons pressed == " + pastryButtonPressCount.ToString());

        if (pastryButtonPressCount >= maximumButtonsToPress)
            Debug.Log(" Pressed maximum pastry buttons!");
            ScoreFeedback.text = "Yay! I'm full of sweets!";

        if (YumSound != null)
        {
            YumSound.SetActive(false);
            YumSound.SetActive(true);
        }

        if (ScoreFeedback == null)

        {
            Debug.LogError("Please assign the FeedbackText object to the script component!", this);
            return;
        }

        else
        {
            ScoreFeedback.text = "Yum! A Pastry!";
         }
         }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetCount()
{
    pastryButtonPressCount = 0;
}
}