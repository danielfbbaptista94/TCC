using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    //DontDestroy dontDestroy;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //dontDestroy.GetComponent<DontDestroy>().DontDestroyMethod();
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}
