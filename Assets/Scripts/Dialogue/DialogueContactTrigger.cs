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

    private IStartDialogue[] iStartDialogue;
    private IFinishDialogue[] iFinishDialogue;
    private IFirstChoice[] iFirstChoice;

    private VisualElement interactPanel;
    private Button interactButton;

    private bool playerInRange;
    private void Awake()
    {
        iStartDialogue = GetComponents<IStartDialogue>();
        iFinishDialogue = GetComponents<IFinishDialogue>();
        iFirstChoice = GetComponents<IFirstChoice>();

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
            if (playerInput.GetInteractPressed())
            {
                interactPanel.style.display = DisplayStyle.None;
                dialogueManager.EnterDialogue(inkJson);
            }
        }
    }

    private void OnEnterDialogue(ClickEvent clickEvent)
    {
        if (playerInRange)
        {
            interactPanel.style.display = DisplayStyle.None;
            dialogueManager.EnterDialogue(inkJson);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && !dialogueManager.dialogueIsPlaying)
        {
            playerInRange = true;
            interactPanel.style.display = DisplayStyle.Flex;

            dialogueManager.StartDialogueEvent = null;
            dialogueManager.FinishDialogueEvent = null;
            dialogueManager.FirstChoiceEvent = null;

            for (int i = 0; i < iStartDialogue.Length; i++)
            {
                if (iStartDialogue[i] != null)
                {
                    dialogueManager.StartDialogueEvent += iStartDialogue[i].MakeAction;
                }
            }

            for (int i = 0; i < iFinishDialogue.Length; i++)
            {
                if (iFinishDialogue[i] != null)
                {
                    dialogueManager.FinishDialogueEvent += iFinishDialogue[i].MakeAction;
                }
            }

            for (int i = 0; i < iFirstChoice.Length; i++)
            {
                if (iFirstChoice[i] != null)
                {
                    dialogueManager.FirstChoiceEvent += iFirstChoice[i].MakeAction;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            interactPanel.style.display = DisplayStyle.None;
        }
    }

    private void OnDisable()
    {
        playerInRange = false;
        interactPanel.style.display = DisplayStyle.None;
    }
}