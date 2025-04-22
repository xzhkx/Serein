using System.Collections.Generic;
using UnityEngine;

public class QF_DeliverItemTrack : MonoBehaviour, IQuestFunctionality
{
    private List<bool> itemTrack = new List<bool>(3);

    private void Start()
    {
        for (int i = 0; i < itemTrack.Count; i++) {
            itemTrack[i] = false;
        }
    }

    public QuestState StartQuestProgress()
    {
        for (int i = 0; i < itemTrack.Count; i++)
        {
            if (!itemTrack[i]) return QuestState.IN_PROGRESS;
        }
        return QuestState.COMPLETE;
    } 

    public void CompleteQuest()
    {

    }
}
