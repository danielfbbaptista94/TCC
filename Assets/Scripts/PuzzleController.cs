using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private GameObject Texts;
    [SerializeField] private GameObject winText;
    [SerializeField] private string _Scene;

    void Start()
    {
        winText.SetActive(false);
    }

    void Update()
    {
        if (PuzzleFisico.locked && PuzzlePsicologico.locked && PuzzleVirtual.locked)
        {
            Texts.SetActive(false);
            winText.SetActive(true);
        }
    }

    public void ButtonOK ()
    {
        winText.SetActive(false);
        PuzzleFisico.locked = false;
        PuzzlePsicologico.locked = false;
        PuzzleVirtual.locked = false;
        SceneManager.LoadScene(_Scene);
    }
}
