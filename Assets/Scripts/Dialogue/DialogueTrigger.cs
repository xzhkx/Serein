using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool playerInRange;

    [SerializeField] private PlayerInput playerInput;

    [Header("Ink File")]
    [SerializeField] private TextAsset inkJson;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        if (!playerInRange) return;
        if (playerInput.GetInteractPressed() && !DialogueManager.Instance.dialogueIsPlaying)
        {
            //SoundManager.Instance.PlaySound(SoundType.OPENUI);
            DialogueManager.Instance.EnterDialogue(inkJson);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}

