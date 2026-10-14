using UnityEngine;
//*** THIS IS LARGELY A QUALITY OF LIFE SCRIPT making it easy for players to quit the game when a keypress is detected.

//*** Focusing on the philosophy that our scripts should really only have one primary job ,
// this Quit on Escape  button pressed script  whole job is to quit our application when escape is pressed
public class QuitOnEscapePressed : MonoBehaviour
{
    void Update()
    {
        //*** There are lots of ways to detect controller andk ey input in Unity, this is the legacy logic I began with
        //and found the most accessible starting out. We call this in Update because EVERY FRAME we want to check if the key was pressed.

        //IF our Input method sees that the Escape Key was pressed , THEN  we quit the application

        if (Input.GetKey(KeyCode.Escape))  //IF this is true
        {
            //THEN we do this

            Application.Quit(); 
        }
    }
}
