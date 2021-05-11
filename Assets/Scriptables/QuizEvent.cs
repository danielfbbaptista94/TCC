using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizEvent", menuName = "QuizEventScriptableObject")]
public class QuizEvent : ScriptableObject
{
    public delegate void UpdateQuestionUICallback(QuestionScriptable question);
    public UpdateQuestionUICallback UpdateQuestionUI;

    public delegate void UpdateQuestionAnswerCallback(AnswerData pickedAnswer);
    public UpdateQuestionAnswerCallback updateQuestionAnswer;

    public delegate void DisplayResolutionScreenCallback(UIController.ResolutionScreenType, int score);
    public DisplayResolutionScreenCallback displayResolutionScreen;

    public delegate void UpdateScoreCallback();
    public UpdateScoreCallback updateScore;
    private int CurrentFinalScore;
}
