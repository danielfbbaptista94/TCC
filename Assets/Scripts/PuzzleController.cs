using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private GameObject Texts;
    [SerializeField] private GameObject winText;

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
}
