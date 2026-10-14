using UnityEngine;

public class PastryScript : MonoBehaviour
{

    public int pastrybuttonPressCount;
    public int maximumButtonsToPress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        void IncrementAndEvaluatePastryButtonPressCount()
         { Debug.Log ("presspastrybutton!");

            pastrybuttonPressCount = pastrybuttonPressCount + 1;
            Debug.Log(" Buttons pressed == " + pastrybuttonPressCount.ToString());

            if (pastrybuttonPressCount >= maximumButtonsToPress)
                Debug.Log(" Pressed maximum pastry buttons!");

    }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
