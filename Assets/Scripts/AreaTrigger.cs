using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AreaTrigger : MonoBehaviour
{
    public GameObject DialogBox;
    public Text DialogText;
    private string dialog;

    private Scene _Scene;

    private void Start()
    {
        _Scene = SceneManager.GetActiveScene();
        Debug.Log(_Scene.name);

        if (_Scene.name == "Sala1")
            dialog = "Bang !";
        else if (_Scene.name == "Sala2")
            dialog = "Bang 2 !!";
        else
            dialog = "Bang !!!";

        Debug.Log(dialog);
    }

    //private void Destroyer()
    //{
    //    Destroy(DialogBox, _Timer);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (DialogBox.activeInHierarchy)
            {
                DialogBox.SetActive(false);
            }
            else
            {
                DialogBox.SetActive(true);
                DialogText.text = dialog;
            }
        }
    }
}
