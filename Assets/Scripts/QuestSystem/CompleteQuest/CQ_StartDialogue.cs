using UnityEngine;

public class CQ_StartDialogue : MonoBehaviour, ICompleteQuest
{
    [SerializeField]
    private Transform dialogueTransform;

    [SerializeField]
    private Transform playerTransform;

    public void MakeAction()
    {
        dialogueTransform.position = playerTransform.position;
    }
}
