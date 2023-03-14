using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS.Data.Save
{
    [Serializable]
    public class NodeSaveData : MonoBehaviour
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public string Text { get; set; }
        [field: SerializeField] public string GroupID { get; set; }
        [field: SerializeField] public Vector2 Position { get; set; }
        [field: SerializeField] public List<string> Choices { get; set; }
    }
}
