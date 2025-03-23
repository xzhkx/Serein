using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    private QuestUIController questUIController;
    public Quest currentQuest { get; private set; }
    private List<Quest> questList = new List<Quest>(10);

    private void Awake()
    {
        Instance = this;
        questUIController = GetComponent<QuestUIController>();
    }

    private void Update()
    {
        if(currentQuest != null)
        {
            currentQuest.StartQuest();
        }
    }

    public void TrackQuest(Quest quest)
    {
        currentQuest = quest;
        quest.SetQuestState(QuestState.IN_PROGRESS);
    }

    public void ReceiveQuest(Quest quest)
    {
        if (currentQuest == null) {
            currentQuest = quest;
        }
        questList.Add(quest);
        quest.SetQuestState(QuestState.EQUIP);
        questUIController.CreateNewQuestUI(quest);
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
