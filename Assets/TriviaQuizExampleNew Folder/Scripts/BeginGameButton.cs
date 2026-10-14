using UnityEngine;


//*** Focusing on the philosophy that our scripts should really only have one primary job ,
// this Begin game buttons whole job is to Begin our quiz 
public class BeginGameButton : MonoBehaviour
{
    public void BeginGamebutton()
    {
        //*** Call our Singletons Begin Quiz  function to start the game
        QuizManager.instance.BeginQuiz();
    }
}
