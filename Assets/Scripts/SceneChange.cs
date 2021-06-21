using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string Scene;
    private bool playerInRange = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && playerInRange)
            SceneManager.LoadScene(Scene);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    public void ClickReturnMenu()
    {
        SceneManager.LoadScene(Scene);
    }
}
