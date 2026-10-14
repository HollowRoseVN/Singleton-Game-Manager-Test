using UnityEngine;
using TMPro;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    //*** Our instance of the Quiz Manager singleton
    public static QuizManager instance;

   
    [HeaderAttribute("Quiz Data")]
    //*** This is the title of our quiz first shown on the Main Menu
    public string quizTitle = "Jonathan and Mirelles' Example Quiz Game";

    [Tooltip("A list of all of our relevant quiz Question and aswer data objects")]

    //*** This list holds all of our quiz question and answer data
    public List<QuizQuestionData> questionData = new List<QuizQuestionData>();

    //*** This is a reference to the current quiz question we are answering and scoring against
    public QuizQuestionData currentQuizQuestion;

    //*** This value holds the amount of time players have for each question;
    public float timeToAnswerEachQuestion = 10f;

    //*** this timer is what holds how much time we currently have to answer a question , when it reaches zero or less it runs out of time
    private float answerTimer = 0f;

    //*** This value holds our position in our list of question data
    private int currentQuestionIndex = 0;

    //*** this records how many correct answers the player has made
    private int correctAnswerCount;

    //*** this boolean records if we are waiting for an answer .
    private bool waitingForAnswer;

    //*** this boolean helps us check if the player has submitted an answer for the current question already
    private bool answerSubmitted;

    //*** The gameobjects have audio sources attached to them and whe turned on play a sound effect
    [Tooltip("These objects are marked PLAY ON Awake so the easiest way to play them is deactivating and activating the objects their audio source is on")]
    [HeaderAttribute("Audio Objects")]
    public GameObject intro_music_Object;
    public GameObject correctAnswer_SFX_Object;
    public GameObject incorrectAnswer_SFX_Object;
    public GameObject waitingForAnswer_SFX_Object;

    [Tooltip("These labels are what display our game UI Text")]
    [HeaderAttribute("UI Elements")]

    //*** these are some of our core UI labels used to convey information to the player including game title, timer  time left
    // our trivia question and our Final Score assessment label
    public TextMeshProUGUI timer_label;
    public TextMeshProUGUI quizMainMenuTitleUI;
    public TextMeshProUGUI quizQuestionUI;
    public TextMeshProUGUI finalScoreText_label;

    //*** the following buttons are seperated by the text on the button and the buton itself
    public TextMeshProUGUI buttonA_Text;
    public Button button_A;

    public TextMeshProUGUI buttonB_Text;
    public Button button_B;

    public TextMeshProUGUI buttonC_Text;
    public Button button_C;

    public TextMeshProUGUI buttonD_Text;
    public Button button_D;

    //*** the nextbutton gameobject
    public GameObject nextButton;

    [Tooltip("These containers house different menu sections of our game including Main Menu, Quiz Question UI,  and the Results Screen")]
    [HeaderAttribute("UI Containers")]

    //*** the following containersh ouse different parts of our UI
    public GameObject MainMenu_Container;
    public GameObject QuizQuestion_Container;

    public GameObject QuizAnswers_Container;

    //*** This gameobject corresponds to our answer icon visual for correct answers
    public GameObject answerIcon_Correct;

    //*** This gameobject corresponds to our answer icon visual for incorrect answers
    public GameObject answerIcon_Incorrect;

    public GameObject FinalScore_Container;
    private void Start()
    {
        //*** We declare our Quiz Manager singleton instance
        if (QuizManager.instance == null)
            instance = this;

        //*** Start the game by activating our Main Menu UI
        DisplayMainmenu();
    }


    private void Update()
    {
        //*** IF Our timer has reached  zero or less yet AND we are waiting for an answer 
        // THEN we force submit a wrong answer to activate our results screen for this question
        if (answerTimer <= 0f && waitingForAnswer == true)
        {
            //*** Mark that we are no longer waiting for answer
            waitingForAnswer = false;

            //*** Force Submit wrong answer of Z 
            ProcessSubmittedAnswer('Z');
        }

        //*** IF we are Waiting for an answer we gradually tick down our answer timer value and 
        //THEN submit the value to our Display Timer function
        if (waitingForAnswer)
        {
            answerTimer -= Time.deltaTime;
            DisplayTimer(answerTimer);
        }  
    }

    //*** This function Displays our Main Menu
    public void DisplayMainmenu()
    {
        //*** We Disable and re-enable the intro music Game Object , their audio sources are marked PlayOnAwake
        intro_music_Object.SetActive(false);
        intro_music_Object.SetActive(true);

        //*** We take our quiz title text string and populate it in our Quiz Title UI
        quizMainMenuTitleUI.text = quizTitle;

        //*** Activate our Main Menu UI but disable the quiz question UI and the final score UI
        MainMenu_Container.SetActive(true);
        QuizQuestion_Container.SetActive(false);

        FinalScore_Container.SetActive(false);
    }

    //*** This function Begins our Quiz and displays quiz question UI
    public void BeginQuiz()
    {
        //*** Activate our Quiz Question UI , , deactivate our main menu UI, and deactivate our Final  Score UI
        QuizQuestion_Container.SetActive(true);
        MainMenu_Container.SetActive(false);
        FinalScore_Container.SetActive(false);

        //*** Reset our correct answer score count , and our current question index to make sure we start at the beginning ofo ur quiz list
        correctAnswerCount = 0;
        currentQuestionIndex = 0;

        //*** Display New Question visuals
        DisplayNewQuestion();
    }

    public void DisplayNewQuestion()
    {
        //*** Populate our Current current quiz question data object
        currentQuizQuestion = questionData[currentQuestionIndex];

        //*** Take the current quiz question data question text and put it into our  Quiz question UI label
        quizQuestionUI.text = currentQuizQuestion.questionText;

        //*** This takes all of the text on our buttons and sets them according to the current questions answer data 
        //*** We add a little string prefix to our answer data for example "A. " to help with highlighting the different answers
        //*** So the player will see  "A. [insert current question answer option]"
        buttonA_Text.text = "A. " + currentQuizQuestion.answerA;
        buttonB_Text.text = "B. " + currentQuizQuestion.answerB;
        buttonC_Text.text = "C. " + currentQuizQuestion.answerC;
        buttonD_Text.text = "D. " + currentQuizQuestion.answerD;

        //*** Mark that we are waiting for an answer, this starts our timer in the update loop
        waitingForAnswer = true;

        //*** Reset that an answer has been submitted as we wait for new answer
        answerSubmitted = false;

        //*** We hide our next question button
        HideNextQuestionButton();

        //*** We hide our incorrect/ correct  Answer icons ( Checkmark / or X)
        HideAnswerIcons();

        //*** We displa our answers UI labels
        DisplayAnswers();

        //*** We reset our answer timer to the max time allowed to answer each question.
        answerTimer = timeToAnswerEachQuestion;

        //*** We disable and re-enable our Waiting for Answer Sound effect audio source.
        waitingForAnswer_SFX_Object.SetActive(false);
        waitingForAnswer_SFX_Object.SetActive(true);
    }

    //*** This function displays the final results of our quiz
    public void DisplayFinalQuizResults()
    {
        //*** Activate our Final Score UI text and buttons while making suire the main menu and Question UI are disabled
        FinalScore_Container.SetActive(true);
        MainMenu_Container.SetActive(false);
        QuizQuestion_Container.SetActive(false);

        //*** We set up this string to share with the player how many answers they got ocrrect, this is the base of our final results text
        string finalScoreBaseText = " You got " + correctAnswerCount.ToString() + " answers correct,";

        //*** Making this switch statement under the assumption we only ever have 5 answers
        //*** would need to be expanded if more questions are added

        //*** We take in how many answers the player got correct
        switch (correctAnswerCount)
        {

            //*** In the CASE that our player got a full 5 /5  in correct answers, we add "Excellent Job" to the tail end of the string
            //** We also color the text to be green to signify a job well done and provide color-based positive feedback
            case 5:

                finalScoreText_label.text = finalScoreBaseText + " Excellent Job!!!";
                finalScoreText_label.color = Color.green;
                break;

            //*** In the CASE that our player got a 4 /5 in correct answers , we add "Great Work" to the tail end of the string
            //** We also color the text to be green- yellow to signify a good job and provide color-based positive feedback
            case 4:
                finalScoreText_label.text = finalScoreBaseText + " Great work !!";
                finalScoreText_label.color = Color.greenYellow;
                break;

            //*** In the CASE that our player got a 3/5 , we add "not bad !" to the tail end of the string
            //** We also color the text to be yellow to signify a ok job and provide color-based middling feedback
            case 3:
                finalScoreText_label.text = finalScoreBaseText + " not bad !";
                finalScoreText_label.color = Color.yellow;
                break;

            //*** In the CASE that our player got a 2/5 , we add " you can do better !" to the tail end of the string
            //** We also color the text to be orange to signify a poor job and provide color-based negative feedback
            case 2:
                finalScoreText_label.text = finalScoreBaseText + " you can do better !";
                finalScoreText_label.color = Color.orange;
                break;

            //*** In the CASE that our player got a 1/5 , we add " YIKES please try again !" to the tail end of the string
            //** We also color the text to be red to signify a bad job and provide color-based negative feedback
            case 1:
                finalScoreText_label.text = finalScoreBaseText + " YIKES please try again !";
                finalScoreText_label.color = Color.red;
                break;

            //*** I forgot to add a case for getting ZERO answers correct, maybe worth adding for experimentation?

            default:
                finalScoreText_label.text = finalScoreBaseText + " SOMETHING WENT WRONG!!!";
                break;
        }
    }

    
    //*** This function taked the answers the player sends when a button is pressed and evaluates if they are correct or incorrect
    public void ProcessSubmittedAnswer(char submittedAnswer)
    {
        //*** This check determines IF an answer was already submitted so that we can't submit multiple answers per question
        if (answerSubmitted == true)
            return;

        //*** If this is our first answer submission to this question then we mark that an answer was submitted to be true.
        answerSubmitted = true;

        //*** We mark that we are no longer waiting for an answer to stop our timer counting down
        waitingForAnswer = false;

        //*** We disable our waiting for answer audio
        waitingForAnswer_SFX_Object.SetActive(false);

        //*** If the submitted correct answer character from our buttons  EQUALS 
        //the same value as our correct answer character noted in the quiz data THEN our answer is correct ELSE our answer is incorrect
        if(currentQuizQuestion.correctAnswerCharacter == submittedAnswer)
        {
            //*** Our actions for a Correct answer
            AnswerWasCorrect();
        }
        else
        {
            //*** Our actions for an Incorrect answer
            AnswerWasIncorrect();
        }
    }

 
    public void AnswerWasCorrect()
    {
        //*** Our answer is correct so we Activate our Correct answer Audio source object
        correctAnswer_SFX_Object.SetActive(false);
        correctAnswer_SFX_Object.SetActive(true);

        // We ALSO Activate our green correct answer icon
        answerIcon_Correct.SetActive(true);

        //*** and we increment the number of answers the player got correct
        correctAnswerCount = correctAnswerCount + 1;

        //*** Display button that allows us to progress the qgameuiz
        DisplayNextQuestionButton();
    }

   public void AnswerWasIncorrect()
    {
        //*** Our answer is incorrect so we Activate our Incorrect answer Audio source object
        incorrectAnswer_SFX_Object.SetActive(false);
        incorrectAnswer_SFX_Object.SetActive(true);

        // We ALSO Activate our rex X incorrect answer icon
        answerIcon_Incorrect.SetActive(true);

        //*** Display button that allows us to progress the game
        DisplayNextQuestionButton();
    }

    public void HideNextQuestionButton()
    {
        //*** This just hides the button that moves us onto the next question, usually during a UI change or new question reveal
        nextButton.SetActive(false);
    }
    public void DisplayNextQuestionButton()
    {
        //*** This shows the button that moves us onto the next question, usually after a trivia question answer was submitted
        nextButton.SetActive(true);

        //*** We hide our trivia answer buttons
        HideAnswers();
    }

    public void HideAnswers()
    {
        //*** Deactivate the quiz answer buttons
        QuizAnswers_Container.SetActive(false);

    }

    public void DisplayAnswers()
    {
        //*** Activate the quiz answer buttons
        QuizAnswers_Container.SetActive(true);

    }

    public void HideAnswerIcons()
    {
        //*** Hide both the correct and incorrect answer icons , particularly when beginning a new question
        answerIcon_Correct.SetActive(false);
        answerIcon_Incorrect.SetActive(false);
    }

    //*** Function which progresses us down the question data list
    public void ContinueToNextQuestion()
    {

        Debug.Log(" current question index : == " + currentQuestionIndex.ToString() + " question data count" + questionData.Count.ToString());
       //*** Increment our index as we move down the list of questions.
       //The visual of our question list index is Question LIST : [0] [1] [2] [3] [4]
       // When we move down the list we are going from Question[0] TO -> Question[1] and then Question[1] O -> Question[2]
        currentQuestionIndex = currentQuestionIndex + 1;

        //*** When we get to the end of our Question list of 5 questions
        //we are checking IS our currenct Question index less than Question[4]
        // When the index reaches 5 or more we have reached the end of our list of questions
        
        //*** If we haven't reached the last question in our list of questions then we can display the next question
        if (currentQuestionIndex <= questionData.Count -1)
        {
            DisplayNewQuestion();
        }
        else //*** If the player has reached the end of our list of questions THEN Hide our answer icons and begin showin our Quiz Result
        {
            HideAnswerIcons();
            FinishedQuizShowResult();
        }
    }

    //*** Finisehd our quiz now show reuslts
    public void FinishedQuizShowResult()
    {
       //*** Display final Quiz Results and 
        DisplayFinalQuizResults();
    }

    //*** Here we Update and display the amount of time Players have to answer the question
    public void DisplayTimer(float time)
    {
        //*** We shorten our Time String to the first 3 digits  and then add it to the itmer text label
        //*** We do the substring call so that a value of 9.1647593940585 seconds becomes simplified to a more digestible  9.1 seconds
        timer_label.text = time.ToString().Substring(0,3);
    }

    
}
