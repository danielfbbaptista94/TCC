using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    QuestionScriptable[] _questions = null;
    [SerializeField] QuizEvent events = null;

    private List<AnswerData> _pickedAnswers = new List<AnswerData>();
    private List<int> _finishedQuestions = new List<int>();
    private int currentQuestion = 0;

    private string _sala;

    void Start()
    {
        _sala = SceneManager.GetActiveScene().name;
        LoadQuestion();
        Debug.Log(_sala);
        Debug.Log("ANTES");
        foreach (var question in _questions)
        {
            Debug.Log(question.Info);
        }

        // Display();
    }

    void LoadQuestion()
    {
        Object[] objects = Resources.LoadAll("Questions/" + _sala, typeof(QuestionScriptable));
        _questions = new QuestionScriptable[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            _questions[i] = (QuestionScriptable) objects[i];
        }
    }

    void Display()
    {
        EresedAnswers();
        var question = GetRandomQuestion();

        if (events.UpdateQuestionUI != null)
        {
            events.UpdateQuestionUI(question);
        } else
        {
            Debug.LogWarning("Algo deu Errado no QuizController > UpdateQuestionUI");
        }
    }

    public void EresedAnswers()
    {
        _pickedAnswers = new List<AnswerData>();
    }

    QuestionScriptable GetRandomQuestion()
    {
        var index = GetRandomQuestionIndex();
        currentQuestion = index;

        return _questions[currentQuestion];
    }

    int GetRandomQuestionIndex()
    {
        var random = 0;
        if(_finishedQuestions.Count < _questions.Length)
        {
            do
            {
                random = Random.Range(0, _questions.Length);
            } while (_finishedQuestions.Contains(random) || random == currentQuestion);
        }
        return random;
    }

    public QuestionScriptable[] Questions { get { return _questions; } }
}
