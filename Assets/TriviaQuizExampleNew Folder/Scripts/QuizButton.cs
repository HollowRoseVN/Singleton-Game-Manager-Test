using UnityEngine;
using UnityEngine.UI;

public class QuizButton : MonoBehaviour
{

    public char answerCharacter = 'A';
    public void SubmitAnswerCharacter()
    {

        if (QuizManager.instance != null)
            QuizManager.instance.ProcessSubmittedAnswer(answerCharacter);

    }
}
