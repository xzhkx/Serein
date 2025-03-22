using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public InGameQuest inGameQuest;

    private QuestUIModel questUIModel;

    public Quest currentQuest { get; private set; }
    private List<Quest> questList = new List<Quest>(10);

    private void Start()
    {
        questUIModel = GetComponent<QuestUIModel>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Quest");
            currentQuest = inGameQuest.GetQuest();
            TrackQuest(currentQuest);
        }
        if(currentQuest != null)
        {
            currentQuest.StartQuest();
        }
    }

    public void TrackQuest(Quest quest)
    {
        currentQuest = quest;
        quest.SetQuestState(QuestState.IN_PROGRESS);
        questUIModel.SetQuestInfo(currentQuest);
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
        return currentQuest;
    }
}
