using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS.Data.Save
{
    public class GraphSaveDataSO : ScriptableObject
    {
        [field: SerializeField] public string FileName { get; set; }

        [field: SerializeField] public List<NodeSaveData> Groups { get; set; }
        [field: SerializeField] public List<NodeSaveData> Nodes { get; set; }

        [field: SerializeField] public List<string> OldGroupNames { get; set; }
        [field: SerializeField] public List<string> OldUngroupedNodeNames { get; set; }

        [field: SerializeField] public Dictionary<string, List<string>> OldGroupedNodeNames { get; set; }
    }
}
