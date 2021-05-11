using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable()]
public struct UIControllerParameters
{
    [Header("Answers Options")]
    [SerializeField] float _margins;

    public float Margins { get { return _margins; } }
}

[Serializable()]
public struct UIElements
{
    [SerializeField] RectTransform _answerContentArea;
    public RectTransform AnswerContentArea { get { return _answerContentArea; } }

    [SerializeField] TextMeshProUGUI _questionInfoTextObject;
    public TextMeshProUGUI QuestionInfoTextObject { get { return _questionInfoTextObject; } }

    [SerializeField] TextMeshProUGUI _scoreText;
    public TextMeshProUGUI ScoreText { get { return _scoreText; } }
}

public class UIController : MonoBehaviour
{
    public enum ResolutionScreenType { Score }

    [Header("References")]
    [SerializeField] QuizEvent _events;

    [Header("UI Elements (Prefabs)")]
    [SerializeField] AnswerData _answerPrefab;

    [SerializeField] UIControllerParameters _parameters;

    [SerializeField] UIElements _uIElements;

    List<AnswerData> currentAnswers = new List<AnswerData>();
}
