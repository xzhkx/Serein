using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink File")]
    [SerializeField]
    private TextAsset inkJson;

    private IFinishDialogue[] iFinishDialogue;
    private IStartDialogue[] iStartDialogue;

    private DialogueManager dialogueManager;
    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        iStartDialogue = GetComponents<IStartDialogue>();
        iFinishDialogue = GetComponents<IFinishDialogue>();
    }

    private void Start()
    {
        dialogueManager = DialogueManager.Instance;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueManager.StartDialogueEvent = null;
            dialogueManager.FinishDialogueEvent = null;

            for (int i = 0; i < iStartDialogue.Length; i++)
            {
                if (iStartDialogue[i] != null)
                {
                    dialogueManager.StartDialogueEvent += iStartDialogue[i].MakeAction;
                }
            }

            for(int i = 0; i < iFinishDialogue.Length; i++)
            {
                if (iFinishDialogue[i] != null)
                {
                    dialogueManager.FinishDialogueEvent += iFinishDialogue[i].MakeAction;
                }
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