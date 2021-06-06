using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    [SerializeField] private GameObject _QuizPanel;
    [SerializeField] private GameObject _QuizResultPanel;
    [SerializeField] private TextMeshProUGUI _ScoreText;

    [SerializeField] private List<QuestionAndAnswer> _QnA;
    [SerializeField] private GameObject[] _Options;
    [SerializeField] private TextMeshProUGUI _QuestionText;
    [SerializeField] private string _Sala;

    private int currentQuestion;
    private int correctAnswers = 0;
    private int countQuestion = 0;

    [SerializeField] private BoolValue booleans;

    private void Start()
    {
        countQuestion = _QnA.Count;
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        if ( _QnA.Count > 0)
        {
            currentQuestion = Random.Range(0,  _QnA.Count);
            _QuestionText.text = _QnA[currentQuestion].Question;
            DisplayAnswers();
        } 
        else
        {
            GameOver();
        }
    }

    void DisplayAnswers()
    {
        for (int i = 0; i < _Options.Length; i++)
        {
            _Options[i].GetComponent<AnswerData>().IsCorrect = false;
            _Options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =  _QnA[currentQuestion].Answers[i];

            if ( _QnA[currentQuestion].CorrectAnswer == i+1)
            {
                _Options[i].GetComponent<AnswerData>().IsCorrect = true;
            }
        }
    }

    public void Correct()
    {
        correctAnswers += 1;
         _QnA.RemoveAt(currentQuestion);
        DisplayQuestion();
    }
    
    public void Wrong()
    {
         _QnA.RemoveAt(currentQuestion);
        DisplayQuestion();
    }

    void GameOver()
    {
        if (correctAnswers >= countQuestion % 2)
            _ScoreText.text = correctAnswers + " / " + countQuestion + "\n" + "A porta está liberada !";
        else
            _ScoreText.text = correctAnswers + " / " + countQuestion + "\n" + "Favor tentar novamente !";

        _QuizPanel.SetActive(false);
        _QuizResultPanel.SetActive(true);
    }

    public void ButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ButtonOK()
    {
        booleans.quiz = true;
        Debug.Log(booleans.quiz);
        SceneManager.LoadScene(_Sala);
    }

}
