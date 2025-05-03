using UnityEngine;

public class CQ_DoneQuest : MonoBehaviour, ICompleteQuest
{
    [SerializeField]
    private QF_QuestSequence questSequence;
    public void MakeAction()
    {
        questSequence.QuestDone();
    }
}
