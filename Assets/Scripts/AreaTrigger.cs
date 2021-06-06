using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AreaTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _DialogBox;
    [SerializeField] private TextMeshProUGUI _DialogText;
    [SerializeField] private string[] _Sentences;
    [SerializeField] private float _TypingSpeed;
    [SerializeField] private GameObject _ContinueButton;

    private int index;
    private bool playerInRange = false;

    [SerializeField] private BoolValue booleans;
    [SerializeField] private GameObject _ButtonSIM;
    [SerializeField] private GameObject _ButtonNO;

    private void Start()
    {
        _DialogText.text = "";
    }

    private void Update()
    {
        if (_DialogText.text == _Sentences[index] && gameObject.name != "Door")
        {
            _ContinueButton.SetActive(true);
        }

        if (!_DialogBox.active)
        {
            if (Input.GetKey(KeyCode.Space) && playerInRange)
            {
                index = 0;
                if (_DialogBox.activeInHierarchy)
                {
                    _DialogBox.SetActive(false);
                }
                else
                {
                    _DialogBox.SetActive(true);
                    StartCoroutine(Typing());
                }
            }
        }
    }

    IEnumerator Typing()
    {
        foreach (char letter in _Sentences[index].ToCharArray())
        {
            _DialogText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            _DialogText.text = "";
            _DialogBox.SetActive(false);

            if (gameObject.name != "Door")
                _ContinueButton.SetActive(false);
        }
    }

    public void ClickButtonContinue()
    {
        _ContinueButton.SetActive(false);

        if (index < _Sentences.Length - 1)
        {
            index++;
            _DialogText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            index = 0;
            _DialogText.text = "";
            _ContinueButton.SetActive(false);
            _DialogBox.SetActive(false);
        }
    }

    public void ClickButtonYES()
    {
        if (booleans.quiz && booleans.puzzle)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            _DialogText.text = "Favor jogar o game Quize e o Quebra-Cabeça para poder sair dessa Sala !";
            StartCoroutine(ManageChangeScene());
        }
    }

    public void ClickButtonNO()
    {
        _DialogText.text = "";
        _DialogBox.SetActive(false);
    }

    IEnumerator ManageChangeScene()
    {
        _ButtonSIM.SetActive(false);
        _ButtonNO.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        _DialogText.text = "";
        _ButtonSIM.SetActive(true);
        _ButtonNO.SetActive(true);
        _DialogBox.SetActive(false);
    }
}
