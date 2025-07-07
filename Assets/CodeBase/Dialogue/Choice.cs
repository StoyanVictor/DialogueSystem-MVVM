using System;
[Serializable]
public class Choice
{
    public string choiceText;
    public ChoiceType choiceType;
    public DialogueNode dialogueNode;
}
public enum ChoiceType
{
    Quest,
    MoneyGive,
    DialogueNode
}