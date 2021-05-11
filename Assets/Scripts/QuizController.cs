using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    [SerializeField] private GameObject _QuizPanel;
    [SerializeField] private GameObject _QuizResultPanel;
    [SerializeField] private TextMeshProUGUI _ScoreText;

    [SerializeField] private List<QuestionAndAnswer> _QnA;
    [SerializeField] private GameObject[] _Options;
    [SerializeField] private TextMeshProUGUI _QuestionText;

    private int currentQuestion;
    private bool playerInRange = false;
    private AreaTrigger areaTrigger = new AreaTrigger();

    private int correctAnswers = 0;

    private void Start()
    {
        _ScoreText.text = "";
    }

    [System.Obsolete]
    private void Update()
    {
        if (!_QuizPanel.active)
        {
            if (Input.GetKey(KeyCode.Space) && playerInRange)
            {
                if (_QuizPanel.activeInHierarchy)
                {
                    _QuizPanel.SetActive(false);
                }
                else
                {
                    _ScoreText.text = "";
                    _QuizPanel.SetActive(true);
                    DisplayQuestion();
                }
            }
        }
        
    }

    void DisplayQuestion()
    {
        if (_QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, _QnA.Count);
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
            _Options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _QnA[currentQuestion].Answers[i];

            if (_QnA[currentQuestion].CorrectAnswer == i+1)
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
        _ScoreText.text = correctAnswers + " / " + _QnA.Count + "\n";

        if (correctAnswers % 2 < _QnA.Count)
        {
            _ScoreText.text = "Favor tentar novamente !";
        } 
        else
        {
            _ScoreText.text = "A porta está liberada !";
        }

        _QuizPanel.SetActive(false);
        _QuizResultPanel.SetActive(true);
    }

    public void ButtonRetry()
    {
        _QuizResultPanel.SetActive(false);
        _QuizPanel.SetActive(true);
        DisplayAnswers();
    }
    
    public void ButtonOK()
    {
        _QuizResultPanel.SetActive(false);
        areaTrigger.ChangeScene = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _QuizPanel.SetActive(false);
    }
}
