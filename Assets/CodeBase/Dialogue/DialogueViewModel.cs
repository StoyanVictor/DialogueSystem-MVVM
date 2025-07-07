using System;
public class DialogueViewModel
{
    private DialogueModel _dialogueModel;
    public event Action onDialogueBegin;
    public event Action onDialogueFinish;
 
    public DialogueViewModel(DialogueModel dialogueModel)
    {
        _dialogueModel = dialogueModel;
        _dialogueModel.onDialogueStarts += () => onDialogueBegin?.Invoke();
        _dialogueModel.onDialogueEnds += () => onDialogueFinish?.Invoke();
    }

    public string GetCurrentSpeakLine() => _dialogueModel.GetCurrentDialogueLine();
    public void SetCurrentNode(DialogueNode dialogueNode) =>  _dialogueModel.SetCurrentNode(dialogueNode);
    public DialogueNode GetCurrentNode() => _dialogueModel.GetCurrentNode();

    public void StartDialogue()
    {
        _dialogueModel.StartDialogue();
    }

    public void EndDilogue()
    {
        _dialogueModel.EndDialogue();
    }
}