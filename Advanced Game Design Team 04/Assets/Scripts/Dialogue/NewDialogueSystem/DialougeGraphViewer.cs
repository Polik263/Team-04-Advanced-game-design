using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor;

public class DialogueGraphViewer : GraphView
{
    private readonly Vector2 _defaultNodeSize = new Vector2(150, 200);

    public DialogueGraphViewer()
    {
        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new ContentDragger());

        AddElement(GenerateEntryPointNode());
    }

    public void CreateNode(string nodeName)
    {
        AddElement(CreateDialogueNode(nodeName));
    }

    private Port GeneratePort(DialogueNode node, Direction portDirection, Port.Capacity capacity = Port.Capacity.Single)
    {
        return node.InstantiatePort(Orientation.Horizontal, portDirection, capacity, typeof(bool));
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        var compatiblePorts = new List<Port>();
        ports.ForEach(port => { if (startPort != port && startPort.node != port.node) { compatiblePorts.Add(port); } });

        return compatiblePorts;
    }

    private DialogueNode GenerateEntryPointNode()
    {
        var node = new DialogueNode
        {
            title = "START",
            GUID = Guid.NewGuid().ToString(),
            DialogueNodeName = "ENTRYPOINT",
            entryPoint = true
        };

        var generatedPort = GeneratePort(node, Direction.Output);
        generatedPort.portName = "Next Entry";
        node.outputContainer.Add(generatedPort);

        node.RefreshExpandedState();
        node.RefreshPorts();

        var button = new Button(() => { AddChoicePort(node, null); });

        node.SetPosition(new Rect(100, 200, 100, 150));
        return node;
    }

    private void AddChoicePort(DialogueNode dialogueNode, string overriddenPortName)
    {
        var generatedPort = GeneratePort(dialogueNode, Direction.Output);

        var outputPortCount = dialogueNode.outputContainer.Query("Connector").ToList().Count;

        var choicePortName = string.IsNullOrEmpty(overriddenPortName) ? $"{outputPortCount}" : overriddenPortName;

        var textField = new TextField
        {
            name = string.Empty,
            value = choicePortName
        };

        textField.RegisterValueChangedCallback(evt => generatedPort.portName = evt.newValue);

        generatedPort.contentContainer.Add(new Label(""));
        generatedPort.contentContainer.Add(textField);

        var deleteButton = new Button(() => RemovePort(dialogueNode, generatedPort))
        {
            text = "X"
        };

        generatedPort.contentContainer.Add(deleteButton);

        generatedPort.portName = choicePortName; 

        dialogueNode.outputContainer.Add(generatedPort);
        dialogueNode.RefreshPorts();
        dialogueNode.RefreshExpandedState();
    }

    private void RemovePort(DialogueNode dialogueNode, Port generatedPort)
    {
        throw new NotImplementedException();
    }

    public DialogueNode CreateDialogueNode(string nodeName)
    {
        var dialogueNode = new DialogueNode
        {
            Name = nodeName,
            DialogueNodeName = nodeName,
            GUID = Guid.NewGuid().ToString()
        };

        var inputPort = GeneratePort(dialogueNode, Direction.Input, Port.Capacity.Multi);
        inputPort.portName = "Input                       :";

        var button = new Button(() => { AddChoicePort(dialogueNode, null); });
        button.text = "Add New Choice";
        dialogueNode.titleContainer.Add(button);

        dialogueNode.Initialize();
        dialogueNode.Draw();

        dialogueNode.inputContainer.Add(inputPort);
        dialogueNode.RefreshExpandedState();
        dialogueNode.RefreshPorts();
        dialogueNode.SetPosition(new Rect(Vector2.zero, _defaultNodeSize));

        return dialogueNode;
    }
}
