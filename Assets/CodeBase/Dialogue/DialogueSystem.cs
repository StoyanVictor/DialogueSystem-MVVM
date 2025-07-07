using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
       [SerializeField] private Dialogue _dialogue;
       [SerializeField] private GameObject _button;
       [SerializeField] private Transform _buttonTransform;
       [SerializeField] private GameObject _dialogueUi;
       [SerializeField] private TextMeshProUGUI _dialogueText;
       [SerializeField] private GameObject _bg;
       public event Action onDialogueStart;
       private DialogueNode _currentDialogueNode;
       
       public void StartDialogue()
       {
           _dialogueText.text = _dialogue.dialogueNodes.speakLine;
           SpawnNodeButtons(_dialogue.dialogueNodes);
           _bg.transform.DOScale(new Vector3(1, 1, 1), 0.7f);
       }

       private void Awake()
       {
           _bg.transform.localScale = new Vector3(0, 0, 0);
       }

       private void SpawnNodeButtons(DialogueNode dialogueNode)
       {
           for (int i = 0; i < dialogueNode.dialogueNodes.Count; i++)
           {
               print(dialogueNode.dialogueNodes.Count);
               var buttonObject = Instantiate(_button,_buttonTransform);
               var node = buttonObject.GetComponent<NodeButton>();
               node._buttonNode = dialogueNode.dialogueNodes[i];
               node._buttonText.text = dialogueNode.dialogueNodes[i].nodeText;
               var button = buttonObject.GetComponent<Button>();
               button.onClick.AddListener(() => ButtonSubscribe(node._buttonNode));
           }
       }
       private  void ClearParent(Transform parent)
       {
           foreach (Transform obj in parent)
           {
               Destroy(obj.gameObject);
           }
       }
       public void ButtonSubscribe(DialogueNode node)
       {
          
           _currentDialogueNode = node;
           if (!_currentDialogueNode.isLastNode)
           {
            _dialogueText.text = _currentDialogueNode.speakLine;
               ClearParent(_buttonTransform);
                SpawnNodeButtons(_currentDialogueNode);
           }
           else
           {
               _bg.transform.DOScale(new Vector3(0, 0, 0), 0.7f);
               ClearParent(_buttonTransform);
           }
       }
       private void Update()
       {
           if (Input.GetKeyDown(KeyCode.D))
           {
               StartDialogue();
           }
       }
}