using UnityEngine;
using UnityEngine.UIElements;

public class DialogueContactTrigger : MonoBehaviour
{
    [SerializeField]
    private UIDocument generalUIDocument;

    [Header("Ink File")]
    [SerializeField]
    private TextAsset inkJson;

    private PlayerInput playerInput;
    private DialogueManager dialogueManager;

    private IStartDialogue iStartDialogue;
    private IFinishDialogue iFinishDialogue;

    private VisualElement interactPanel;
    private Button interactButton;

    private bool playerInRange;
    private void Awake()
    {
        iStartDialogue = GetComponent<IStartDialogue>();
        iFinishDialogue = GetComponent<IFinishDialogue>();

        interactPanel = generalUIDocument.rootVisualElement.Q<VisualElement>("InteractItemPanel");
        interactPanel.style.display = DisplayStyle.None;

        interactButton = generalUIDocument.rootVisualElement.Q<Button>("InteractButton");
        interactButton.RegisterCallback<ClickEvent>(OnEnterDialogue);
    }

    private void Start()
    {
        playerInput = PlayerInput.Instance;
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

            if (iStartDialogue != null)
            {
                dialogueManager.StartDialogueEvent += iStartDialogue.MakeAction;
            }
            if (iFinishDialogue != null)
            {
                dialogueManager.FinishDialogueEvent += iFinishDialogue.MakeAction;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            interactPanel.style.display = DisplayStyle.None;

            if (iStartDialogue != null)
            {
                dialogueManager.StartDialogueEvent -= iStartDialogue.MakeAction;
            }
            if (iFinishDialogue != null) {
                dialogueManager.FinishDialogueEvent -= iFinishDialogue.MakeAction;
            }
        }
    }
}
