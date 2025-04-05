using UnityEngine;
using UnityEngine.UIElements;

public class DialogueContactTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private UIDocument generalUIDocument;

    [Header("Ink File")]
    [SerializeField]
    private TextAsset inkJson;

    private IFinishDialogue iFinishDialogue;
    private DialogueManager dialogueManager;

    private VisualElement interactPanel;
    private Button interactButton;

    private bool playerInRange;
    private void Awake()
    {
        iFinishDialogue = GetComponent<IFinishDialogue>();

        interactPanel = generalUIDocument.rootVisualElement.Q<VisualElement>("InteractItemPanel");
        interactPanel.style.display = DisplayStyle.None;

        interactButton = generalUIDocument.rootVisualElement.Q<Button>("InteractButton");
        interactButton.RegisterCallback<ClickEvent>(OnEnterDialogue);
    }

    private void Start()
    {
        playerInRange = false;
        dialogueManager = DialogueManager.Instance;
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (playerInput.GetInteractPressed() && !dialogueManager.dialogueIsPlaying)
            {
                interactPanel.style.display = DisplayStyle.None;
                dialogueManager.EnterDialogue(inkJson);
            }
        }
    }

    private void OnEnterDialogue(ClickEvent clickEvent)
    {
        if (playerInRange && !dialogueManager.dialogueIsPlaying)
        {
            interactPanel.style.display = DisplayStyle.None;
            dialogueManager.EnterDialogue(inkJson);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            interactPanel.style.display = DisplayStyle.Flex;

            if (iFinishDialogue == null) return;
            dialogueManager.FinishDialogueEvent += iFinishDialogue.MakeAction;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            interactPanel.style.display = DisplayStyle.None;

            if (iFinishDialogue == null) return;
            dialogueManager.FinishDialogueEvent -= iFinishDialogue.MakeAction;
        }
    }
}
