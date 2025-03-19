using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public InGameQuest inGameQuest;

    private QuestUIView questUIView;

    public Quest currentQuest { get; private set; }
    private List<Quest> questList = new List<Quest>(10);

    private void Awake()
    {
        questUIView = GetComponent<QuestUIView>();
    }

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
            questUIView.SetQuestInfo(currentQuest);
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
        return currentQuest;
    }
}
