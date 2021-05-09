using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Answer
{
    [SerializeField] private string _info;
    [SerializeField] private bool _isCorrect;

    public string Info { get { return _info; } }
    public bool IsCorrect { get { return _isCorrect; } }
}

public enum AnswerTypes { Sigle, Multi }

public class QuestionScriptable : ScriptableObject
{
    [SerializeField] private string _info = string.Empty;
    [SerializeField] Answer[] _answers = null;
    [SerializeField] private AnswerTypes _answerType = AnswerTypes.Multi;
    [SerializeField] private int _addScore = 10;

    public string Info { get { return _info; } }
    public Answer[] Answers { get { return _answers; } }
    public AnswerTypes GetAnswerTypes { get { return _answerType; } }
    public int AddScore { get { return _addScore; } }

    public List<int> GetCorrectAnswers()
    {
        List<int> CorrectAnswers = new List<int>();
        for(int i = 0; i <= Answers.Length; i++)
        {
            if (Answers[i].IsCorrect)
            {
                CorrectAnswers.Add(i);
            }
        }
        return CorrectAnswers;
    }
}
