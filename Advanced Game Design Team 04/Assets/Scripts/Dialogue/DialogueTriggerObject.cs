using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerObject : MonoBehaviour
{
    //public List<DialogueBox[]> DialogueCollection = new List<DialogueBox[]>();

    public DialogueBox[] DialogueSequence;

    public DialogueTrigger triggerCondition { get; set; } = DialogueTrigger.OnTriggerEnter;

    public enum DialogueTrigger
    {
        OnTriggerEnter,
        OnKill,
        Time,
        OnEvent
    }
}
