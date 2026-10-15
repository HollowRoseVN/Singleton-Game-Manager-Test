using UnityEngine;

public class PastryScript : MonoBehaviour
{

    public int pastryButtonPressCount;
    public int maximumButtonsToPress;

    [HeaderAttribute("AudioManager")]
    public GameObject YumSound;

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

        YumSound.SetActive(false);     
        YumSound.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
