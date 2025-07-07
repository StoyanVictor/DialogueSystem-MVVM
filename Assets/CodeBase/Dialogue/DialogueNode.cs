using System.Collections.Generic;

[System.Serializable]
public class DialogueNode
{
    public string speakLine;
    public string nodeText;
    public bool isLastNode;
    public List<DialogueNode> dialogueNodes = new List<DialogueNode>();
}