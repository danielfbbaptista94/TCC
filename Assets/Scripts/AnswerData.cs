using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerData : MonoBehaviour
{
    private bool _IsCorrect = false;
    [SerializeField] private QuizController quiz;

    public void Answer()
    {
        if (_IsCorrect)
        {
            Debug.Log("Resposta Correta.");
            quiz.Correct();
        }
        else
        {
            Debug.Log("Resposta Incorreta.");
            quiz.Wrong();
        }
    }

    public bool IsCorrect 
    { 
        get { return _IsCorrect; } 
        set { _IsCorrect = value; } 
    }
}
