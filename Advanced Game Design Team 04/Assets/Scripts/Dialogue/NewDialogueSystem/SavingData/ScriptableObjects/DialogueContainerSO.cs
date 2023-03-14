using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace DS.ScriptableObjects
{
    public class DialogueContainerSO : ScriptableObject
    {
        public string FileName { get; set; }
        public SerializedDictionary<DialogueSO, List<DialogueSO>> DialogueGroups { get; set; }
        public List<DialogueSO> UngroupedDialogue { get; set; }

        public void Initialize(string fileName)
        {
            FileName = fileName;

            DialogueGroups = new SerializedDictionary<DialogueSO, List<DialogueSO>>();
            UngroupedDialogue = new List<DialogueSO>();
        }
    }
}
