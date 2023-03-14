using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS.Data
{
    using ScriptableObjects;

    public class ChoiceData : MonoBehaviour
    {
        [field: SerializeField] public string Text { get; set; }
        [field: SerializeField] public DialogueSO NextDialogue { get; set; }
    }
}
