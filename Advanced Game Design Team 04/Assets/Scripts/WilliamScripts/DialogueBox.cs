using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "New Dialogue Box", menuName = "Dialogue")]
public class DialogueBox : ScriptableObject
{
    [Header("Dialogue Information")]
    public string SpeakerName;
    public string DialogueText;
    public string[] DialogueOptions = new string[4];

    [Header("Text Speed")]
    [Range(0f, 1f)] public float LetterDelaySpeed;

    [Header("Color and Customization")]

    public Color TextColor = new Color(255, 255, 255, 255);
    public Color BorderColor = new Color(255, 255, 255, 255);
    public Color BackgroundColor = new Color(255, 255, 255, 255);
}
