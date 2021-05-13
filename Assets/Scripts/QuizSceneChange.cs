﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizSceneChange : MonoBehaviour
{
    [SerializeField] private string _Quiz;
    private bool playerInRange = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && playerInRange)
            SceneManager.LoadScene(_Quiz);
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