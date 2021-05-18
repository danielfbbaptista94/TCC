using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private GameObject winText;

    [SerializeField] private GameObject Texts;

    // Use this for initialization
    void Start()
    {
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PuzzleFisico.locked && PuzzlePsicologico.locked && PuzzleVirtual.locked)
        {
            Texts.SetActive(false);
            winText.SetActive(true);
        }
    }
}
