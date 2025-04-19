using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink File")]
    [SerializeField]
    private TextAsset inkJson;

    private IFinishDialogue iFinishDialogue;
    private IStartDialogue iStartDialogue;

    private DialogueManager dialogueManager;
    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        iStartDialogue = GetComponent<IStartDialogue>();
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
            if (iStartDialogue != null)
            {
                dialogueManager.StartDialogueEvent = null;
                dialogueManager.StartDialogueEvent += iStartDialogue.MakeAction;
            }
            if (iFinishDialogue != null)
            {
                dialogueManager.FinishDialogueEvent = null;
                dialogueManager.FinishDialogueEvent += iFinishDialogue.MakeAction;
            }
            dialogueManager.EnterDialogue(inkJson);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxCollider.enabled = false;
        }
    }
}