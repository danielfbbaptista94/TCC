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
    private bool _ChangeScene = false;

    private void Start()
    {
        _DialogText.text = "";
    }

    private void Update()
    {
        if ( _DialogText.text == _Sentences[index] && gameObject.name != "Door")
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
        Debug.Log(ChangeScene);
        if (ChangeScene)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ClickButtonNO()
    {
        _DialogText.text = "";
        _DialogBox.SetActive(false);
    }

    public bool ChangeScene { get { return _ChangeScene; } set { _ChangeScene = value; } }
}
