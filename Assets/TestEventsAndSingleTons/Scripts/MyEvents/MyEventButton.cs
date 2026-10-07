using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameButton : MonoBehaviour
{
    public bool wasPressed = false;

    public UnityEvent OnButtonPress;

    public void PressButton()
    {

        if (wasPressed == false)
        {
            Debug.Log("Event  Button Pressed , incrementing count ! button name: " + this.gameObject.name);

            wasPressed = true;

            OnButtonPress?.Invoke();
            

        }
        else
        {
            Debug.Log("This  Eventbutton was already pressed , not incrementing count");

        }

    }

}