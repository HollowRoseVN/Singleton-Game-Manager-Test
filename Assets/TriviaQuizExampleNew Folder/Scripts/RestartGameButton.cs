using UnityEngine;

//*** Focusing on the philosophy that our scripts should really only have one primary job ,
// this Restart game buttons whole job is to restart our quiz  and reset the game back to the main menu
public class RestartGameButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RestartGame()
    {
        //*** Call our Singletons Display Main Menu  function to reset back to our main menu UI
        QuizManager.instance.DisplayMainmenu();
    }
}
