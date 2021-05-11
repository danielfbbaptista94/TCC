using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerData : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI infoTextObject;
    [SerializeField] private Image toggle;

    [Header("Textures")]
    [SerializeField] private Sprite uncheckedToggle;
    [SerializeField] private Sprite checkedToggle;

    private int _answerIndex = -1;

    public int AnswerIndex { get { return _answerIndex; } }
}
