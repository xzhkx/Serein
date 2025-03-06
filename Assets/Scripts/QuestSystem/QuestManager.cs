using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public InGameQuest inGameQuest;

    public Quest currentQuest { get; private set; }
    private List<Quest> questList = new List<Quest>(10);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentQuest = inGameQuest.GetQuest();
            TrackQuest(currentQuest);
        }
        if(currentQuest != null)
        {
            currentQuest.StartQuest();
            //SetUIQuestInfo();
        }
    }

    public void TrackQuest(Quest quest)
    {
        currentQuest = quest;
        quest.SetQuestState(QuestState.IN_PROGRESS);
    }

    public void ReceiveQuest(Quest quest)
    {
        questList.Add(quest);
        quest.SetQuestState(QuestState.EQUIP);
    }

    public void StartQuest()
    {
        currentQuest.StartQuest();
    }

    public Quest GetCurrentQuest()
    {
        Debug.Log("GetCurrentQuest");
        return currentQuest;
    }
}
