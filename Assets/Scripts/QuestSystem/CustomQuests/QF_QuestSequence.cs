using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QF_QuestSequence : MonoBehaviour, IQuestFunctionality
{
    [SerializeField]
    private int questCount;

    private ICompleteQuest[] iCompleteQuests;

    private void Awake()
    {
        iCompleteQuests = GetComponents<ICompleteQuest>();
    }

    public QuestState StartQuestProgress()
    {
        if (questCount == 0)
            return QuestState.COMPLETE;
        else return QuestState.IN_PROGRESS;
    }

    public void QuestDone()
    {
        questCount--;
    }

    public void CompleteQuest()
    {
        for (int i = 0; i < iCompleteQuests.Length; i++)
        {
            iCompleteQuests[i].MakeAction();
        }
    }
}
