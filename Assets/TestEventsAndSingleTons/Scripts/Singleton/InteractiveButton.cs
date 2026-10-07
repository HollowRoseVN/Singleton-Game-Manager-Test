using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveButton : MonoBehaviour
{

    public bool wasPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PressButton()
    {

        if(wasPressed == false)
        {
            Debug.Log("New Button Pressed , incrementing count ! button name: " + this.gameObject.name );

            wasPressed = true;


            GameController.instance.ButtonPressedIncrementCount();

        }
        else
        {
            Debug.Log("This button was already pressed , not incrementing count");

        }

    }
}
