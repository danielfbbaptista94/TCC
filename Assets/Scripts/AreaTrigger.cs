using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaTrigger : MonoBehaviour
{
    public GameObject DialogBox;
    public Text DialogText;
    private string dialog;

    private float _Timer = 0.8f;
    private int _Pass = 0;

    private void Start()
    {
        dialog = "Bang !!!";
    }

    private void Destroyer()
    {
        Destroy(DialogBox, _Timer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_Pass == 0)
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
                    Destroyer();
                }
            }
            _Pass++;
        }
    }
}
