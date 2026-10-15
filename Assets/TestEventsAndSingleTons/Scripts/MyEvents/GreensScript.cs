using UnityEngine;

public class GreensScript : MonoBehaviour
{
    public int buttonPressCount;
    public int maximumButtonsToPress;

    [HeaderAttribute("AudioManager")]
    public GameObject YuckSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {}
        public void IncrementAndEvaluateButtonPressCount()
         { Debug.Log ("pressgreensbutton!");

            buttonPressCount = buttonPressCount - 1;
            Debug.Log(" Buttons pressed == " + buttonPressCount.ToString());

            if (buttonPressCount >= maximumButtonsToPress)
                Debug.Log(" Pressed maximum buttons!");

            YuckSound.SetActive(false); 
            YuckSound.SetActive(true);

         }
    // Update is called once per frame
    void Update()
    {
        
    }
}
