using System.Collections.Generic;
using UnityEngine;

public class QF_DeliverItemTrack : MonoBehaviour, IQuestFunctionality
{
    [SerializeField]
    private List<int> itemTrack = new List<int>(5);

    public QuestState StartQuestProgress()
    {
        if (itemTrack.Count == 0) return QuestState.COMPLETE;
        return QuestState.IN_PROGRESS;
    } 

    public void DeliverSuccess(int itemID)
    {
        itemTrack.Remove(itemID);
    }

    public void CompleteQuest()
    {

    }
}
