using UnityEngine;

//*** Focusing on the philosophy that our scripts should really only have one primary job ,
// this Next Question  buttons whole job is to call our Continue to Next question function on the Quiz Manager
public class NextQuestionButton : MonoBehaviour
{
    public void GoToNextQuestion()
    {
        //*** Call our Singletons Continue to Next Question   function to continue whatever is next according to our quiz setup
        QuizManager.instance.ContinueToNextQuestion();
    }
}
