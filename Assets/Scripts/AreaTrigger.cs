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

    private void Start()
    {
        DialogText.text = "";
    }

    private void Update()
    {
        if ( DialogText.text == sentences[index] && gameObject.name != "Door")
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
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            DialogText.text = "";
            DialogBox.SetActive(false);

            if (gameObject.name != "Door")
                continueButton.SetActive(false);
        }
    }

    public void ClickButtonContinue()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            DialogText.text = "";
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

    public void ClickButtonYES()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ClickButtonNO()
    {
        DialogText.text = "";
        DialogBox.SetActive(false);
    }

}
