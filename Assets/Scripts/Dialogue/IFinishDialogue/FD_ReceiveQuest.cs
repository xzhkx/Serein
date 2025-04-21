using UnityEngine;

public class FD_ReceiveQuest : MonoBehaviour, IFinishDialogue
{
    [SerializeField]
    private InGameQuest inGameQuest;

    public void MakeAction()
    {
        inGameQuest.ReceiveQuest();
    }
}
