using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange current;

    //public GameObject DialogBox;
    //public Text DialogText;
    //private string dialog;
    private bool inRange = false;

    private string Sala;
    //public int id;

    private void Start() {
        Sala = gameObject.name;
        //dialog = "Deseja entrar na sala: " + Sala + ". \n Clique em uma das opções abaixo:";
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {

            //if (DialogBox.activeInHierarchy)
            //{
            //    DialogBox.SetActive(false);
            //} else
            //{
                //DialogBox.SetActive(true);
                //DialogText.text = dialog;
                SceneManager.LoadScene(Sala, LoadSceneMode.Single);
            //}
        }
    }

    

    

}
