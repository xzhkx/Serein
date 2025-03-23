using UnityEngine;

public class ReceiveQuestDialogue : MonoBehaviour, IFinishDialogue
{
    [SerializeField]
    private InGameQuest inGameQuest;
    public void MakeAction()
    {
        inGameQuest.ReceiveQuest();
    }
}
