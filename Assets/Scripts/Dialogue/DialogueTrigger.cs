using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] 
    private PlayerInput playerInput;

    [Header("Ink File")]
    [SerializeField] 
    private TextAsset inkJson;

    private IFinishDialogueAction finishDialogueAction;
    private DialogueManager dialogueManager;
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        finishDialogueAction = GetComponent<IFinishDialogueAction>();
    }

    private void Start()
    {
        dialogueManager = DialogueManager.Instance;
    }

    private void Update()
    {
        if (!playerInRange) return;
        if (playerInput.GetInteractPressed() && !dialogueManager.dialogueIsPlaying)
        {
            dialogueManager.EnterDialogue(inkJson);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            if (finishDialogueAction == null) return;
            dialogueManager.FinishDialogueEvent += finishDialogueAction.MakeAction;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            if (finishDialogueAction == null) return;
            dialogueManager.FinishDialogueEvent -= finishDialogueAction.MakeAction;
        }
    }
}

