using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AreaTrigger : MonoBehaviour
{
    [SerializeField] private GameObject DialogBox;
    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private string[] sentences;
    private int index;
    [SerializeField] private float typingSpeed;

    [SerializeField] private GameObject continueButton;

    private bool playerInRange = false;
    private Scene _Scene;
    private string sala;

    private void Start()
    {
        DialogText.text = "";
        _Scene = SceneManager.GetActiveScene();

        if (_Scene.name == "Sala1")
            sala = "Sala1 !";
        else if (_Scene.name == "Sala2")
            sala = "Sala2 !!";
        else
            sala = "Sala3 !!!";

        Debug.Log(sala);
    }

    private void Update()
    {
        if (DialogText.text == sentences[index])
        {
            continueButton.SetActive(true);
        }

        if (!DialogBox.active)
        {
            if (Input.GetKey(KeyCode.Space) && playerInRange)
            {
                index = 0;
                if (DialogBox.activeInHierarchy)
                {
                    DialogBox.SetActive(false);
                }
                else
                {
                    DialogBox.SetActive(true);
                    //DialogText.text = sentences[0];
                    StartCoroutine(Typing());
                }
            }
        }
    }

    IEnumerator Typing()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            
            //if (DialogBox.activeInHierarchy)
            //{
            //    DialogBox.SetActive(false);
            //}
            //else
            //{
            //    DialogBox.SetActive(true);
            //    StartCoroutine(Typing());
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            DialogText.text = "";
            continueButton.SetActive(false);
            DialogBox.SetActive(false);
        }
    }

    public void ClickButtonContinue()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            DialogText.text = "";
            //DialogText.text = sentences[index];
            StartCoroutine(Typing());
        }
        else
        {
            index = 0;
            DialogText.text = "";
            continueButton.SetActive(false);
            DialogBox.SetActive(false);
        }
    }

}
