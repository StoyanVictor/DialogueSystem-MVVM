using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogueView : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogueData;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private GameObject _exitButtonPrefab;
    [SerializeField] private Transform _buttonsParent;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Image _bg;
    
    private UiAnimator _uiAnimator;
    private DialogueViewModel _dialogueViewModel;
    public void SpawnNodeButtons(DialogueNode dialogueNode)
    {
        _buttonPrefab.transform.localScale = new Vector3(0, 0, 0);
        for (int i = 0; i < dialogueNode.dialogueNodes.Count; i++)
        {
            var buttonObject = Instantiate(_buttonPrefab,_buttonsParent);
            _uiAnimator.ScaleOutIn(buttonObject.transform,0.7f);
            var node = buttonObject.GetComponent<NodeButton>();
            node._buttonNode = dialogueNode.dialogueNodes[i];
            node._buttonText.text = dialogueNode.dialogueNodes[i].nodeText;
            var button = buttonObject.GetComponent<Button>();
            button.onClick.AddListener(() => OpenCurrentNode(node._buttonNode));
        }
    }
    public void OpenCurrentNode(DialogueNode node)
    {
        _dialogueViewModel.SetCurrentNode(node);
        var _currentDialogueNode = _dialogueViewModel.GetCurrentNode();
        if (!_currentDialogueNode.isLastNode)
        {
            _dialogueText.text = _dialogueViewModel.GetCurrentSpeakLine();
            _dialogueText.transform.localScale = new Vector3(0, 0, 0);
            _uiAnimator.ScaleOutIn(_dialogueText.transform,0.5f);
            ClearParent(_buttonsParent);
            SpawnNodeButtons(_currentDialogueNode);
        }
        else
        {
            ClearParent(_buttonsParent);
            _dialogueViewModel.EndDilogue();
        }
    }

    public void SpawnExitButton()
    {
        var exitObj = Instantiate(_exitButtonPrefab, _buttonsParent);
        var exitButton = exitObj.GetComponent<Button>();
        exitButton.onClick.AddListener(() => ExitDialogue());
    }

    private void ExitDialogue()
    {
        _dialogueViewModel.SetCurrentNode(null);
        _uiAnimator.ScaleInOut(_bg.transform,0.5f);
        _uiAnimator.DestroyAllTweens(_bg.transform);
        ClearParent(_buttonsParent);
    }
    private void Awake()
    {
        InitDialogue();
        _dialogueViewModel.StartDialogue();
    }

    private void InitDialogue()
    {
        _bg.transform.localScale = new Vector3(0, 0, 0);
        _uiAnimator = new UiAnimator();
        _dialogueViewModel = new DialogueViewModel(new DialogueModel());
        _dialogueViewModel.onDialogueBegin += () => ScaleBackground(_bg.transform, 0.4f);
        _dialogueViewModel.onDialogueBegin += () => SpawnNodeButtons(_dialogueData.dialogueNodes);
        _dialogueViewModel.onDialogueFinish += () => SpawnExitButton();
    }

    private void ScaleBackground(Transform gameObjectTransform,float animationTime)
    {
        _uiAnimator.ScaleOutIn(gameObjectTransform,animationTime);
    }
    private  void ClearParent(Transform parent)
    {
        foreach (Transform obj in parent)
        {
           Destroy(obj.gameObject);
           _uiAnimator.DestroyAllTweens(obj);
        }
    }
}