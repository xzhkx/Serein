using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] 
    private PlayerInput playerInput;

    [Header("Ink File")]
    [SerializeField] 
    private TextAsset inkJson;

    private IFinishDialogue iFinishDialogue;
    private DialogueManager dialogueManager;
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        iFinishDialogue = GetComponent<IFinishDialogue>();
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
            if (iFinishDialogue == null) return;
            dialogueManager.FinishDialogueEvent += iFinishDialogue.MakeAction;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            if (iFinishDialogue == null) return;
            dialogueManager.FinishDialogueEvent -= iFinishDialogue.MakeAction;
        }
    }
}

