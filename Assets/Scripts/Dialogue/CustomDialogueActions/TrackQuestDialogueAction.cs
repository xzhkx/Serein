using UnityEngine;

public class TrackQuestDialogueAction : MonoBehaviour, IFinishDialogueAction
{
    [SerializeField]
    private InGameQuest inGameQuest;
    public void MakeAction()
    {
        inGameQuest.TrackQuest();
    }
}
