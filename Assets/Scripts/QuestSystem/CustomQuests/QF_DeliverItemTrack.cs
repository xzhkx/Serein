using System.Collections.Generic;
using UnityEngine;

public class QF_DeliverItemTrack : MonoBehaviour, IQuestFunctionality
{
    [SerializeField]
    private List<int> itemTrack = new List<int>(5);

    private ICompleteQuest[] iCompleteQuests;

    private void Awake()
    {
        iCompleteQuests = GetComponents<ICompleteQuest>();
    }

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
        for (int i = 0; i < iCompleteQuests.Length; i++) 
        {
            iCompleteQuests[i].MakeAction();
        }
    }
}
