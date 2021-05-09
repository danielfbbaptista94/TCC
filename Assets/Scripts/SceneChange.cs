using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private GameObject DialogBox;
    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private string[] sentences;
    private int index;
    [SerializeField] private float typingSpeed;

    private string Sala;

    private void Start() {
        Sala = gameObject.name;
    }

    IEnumerator Typing()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {

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

    public void ClickButtonYES()
    {
        // SceneManager.LoadScene(Sala, LoadSceneMode.Single);
        SceneManager.LoadSceneAsync(Sala, LoadSceneMode.Single);
    }

    public void ClickButtonNO()
    {
        DialogText.text = "";
        DialogBox.SetActive(false);
    }

}
