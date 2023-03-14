using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DS.Data.Save
{
    [Serializable]
    public class ChoiceSaveData : MonoBehaviour
    {
        [field: SerializeField] public string Text { get; set; }
        [field: SerializeField] public string NodeId { get; set; }
    }
}
