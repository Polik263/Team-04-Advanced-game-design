using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace DS.Elements
{
    public class DialogueGraph : EditorWindow
    {
        private DialogueGraphViewer _graphView;

        private string _fileName = "FileName";

        [MenuItem("Dialogue Manager/Dialogue Graph Editor")]
        public static void OpenDialogueGraphWindow()
        {
            var window = GetWindow<DialogueGraph>();
            window.titleContent = new GUIContent("Dialogue Graph");
        }

        private void OnEnable()
        {
            ConstructDialogueGraph();
            GenerateToolbar();
        }

        private void ConstructDialogueGraph()
        {
            _graphView = new DialogueGraphViewer
            {
                name = "Dialogue Graph"
            };

            _graphView.StretchToParentSize();
            rootVisualElement.Add(_graphView);
        }

        private void GenerateToolbar()
        {
            var toolbar = new Toolbar();

            var nodeCreateButton = new Button(() => { _graphView.CreateNode("Dialogue Node"); });
            nodeCreateButton.text = "Create New Dialogue Node";
            toolbar.Add(nodeCreateButton);

            var fileNameTextField = new TextField(_fileName);
            fileNameTextField.SetValueWithoutNotify(_fileName);
            fileNameTextField.MarkDirtyRepaint();
            fileNameTextField.RegisterValueChangedCallback(evt => _fileName = evt.newValue);
            toolbar.Add(fileNameTextField);

            toolbar.Add(new Button(() => SaveData()) { text = "Save Data" });
            toolbar.Add(new Button(() => SaveData()) { text = "Load Data" });

            rootVisualElement.Add(toolbar);
        }

        private void SaveData()
        {

        }

        private void LoadData()
        {

        }

        private void OnDisable()
        {
            rootVisualElement.Remove(_graphView);
        }
    }
}
