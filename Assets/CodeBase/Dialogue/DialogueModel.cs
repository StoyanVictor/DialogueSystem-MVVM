using System;

public class DialogueModel
{
    private DialogueNode _currentDialogueNode;
    private string _dialogueLine;
    public event Action onDialogueStarts;
    public event Action onDialogueEnds;

    public string GetCurrentDialogueLine() => _currentDialogueNode.speakLine;
    public DialogueNode GetCurrentNode() => _currentDialogueNode;   
    public void SetCurrentNode(DialogueNode node) => _currentDialogueNode = node;

    public void StartDialogue()
    {
        onDialogueStarts?.Invoke();
    }
    public void EndDialogue()
    {
        if(_currentDialogueNode.isLastNode)
            onDialogueEnds?.Invoke();
        else return;
    }
}