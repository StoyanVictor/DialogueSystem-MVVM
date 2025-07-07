using System.Collections.Generic;
[System.Serializable]
public class DialogueNode
{
    public string speakLine;
    public bool isLastNode;
    public List<Choice> choices = new List<Choice>();
}