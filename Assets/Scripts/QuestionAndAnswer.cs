using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionAndAnswer
{
    [SerializeField] private string _Question;
    [SerializeField] private string[] _Answers;
    [SerializeField] private int _CorrectAnswer;

    public string Question { get { return _Question; } }
    public string[] Answers { get { return _Answers; } }
    public int CorrectAnswer { get { return _CorrectAnswer; } }
}
