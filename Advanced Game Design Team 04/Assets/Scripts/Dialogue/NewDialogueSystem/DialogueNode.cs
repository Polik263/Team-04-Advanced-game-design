using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor;

public class DialogueNode : Node
{
    public string GUID;
    public string Name;
    public string DialogueNodeName;
    public string DialogueText = "Sample Text";

    public List<string> Choices { get; set; }

    public bool entryPoint = false;

    public void Initialize()
    {
        Choices = new List<string>();
    }

    public void Draw()
    {
        TextField nodeName = new TextField()
        {
            value = DialogueNodeName
        };

        titleContainer.Insert(0, nodeName);

        VisualElement customDataContainer = new VisualElement();

        Foldout dialogueTextFoldout = new Foldout()
        {
            text = "Dialogue Text"
        };

        TextField dialogueTextField = new TextField()
        {
            value = DialogueText
        };

        //foreach (string choice in Choices)
        //{
        //    Port choicePort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));

        //    choicePort.portName = choice;

        //    Button deleteChoiceButton = new Button()
        //    {
        //        text = "X"
        //    };

        //    TextField choiceTextField = new TextField()
        //    {
        //        value = choice
        //    };

        //    choicePort.Add(choiceTextField);
        //    choicePort.Add(deleteChoiceButton);

        //    outputContainer.Add(choicePort);
        //}

        dialogueTextFoldout.Add(dialogueTextField);

        customDataContainer.Add(dialogueTextFoldout);
        extensionContainer.Add(customDataContainer);
    }
}
