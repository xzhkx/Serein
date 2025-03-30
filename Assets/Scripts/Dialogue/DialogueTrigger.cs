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
    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        iFinishDialogue = GetComponent<IFinishDialogue>();
    }

    private void Start()
    {
        dialogueManager = DialogueManager.Instance;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueManager.EnterDialogue(inkJson);
            if (iFinishDialogue == null) return;
            dialogueManager.FinishDialogueEvent += iFinishDialogue.MakeAction;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (iFinishDialogue == null) return;
            dialogueManager.FinishDialogueEvent -= iFinishDialogue.MakeAction;
            boxCollider.enabled = false;
        }
    }
}

