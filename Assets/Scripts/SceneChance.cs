using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChance : MonoBehaviour
{
    [SerializeField] private string _Scene;
    private bool playerInRange = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && playerInRange)
            SceneManager.LoadScene(_Scene);
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
}
