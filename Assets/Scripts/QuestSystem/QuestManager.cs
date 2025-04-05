using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    private QuestUIController questUIController;
    public Quest currentQuest { get; private set; }
    private List<Quest> questList = new List<Quest>(10);

    private Camera mainCamera;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
        questUIController = GetComponent<QuestUIController>();
    }

    private void Update()
    {
        if (currentQuest == null) return;

        QuestState state = currentQuest.StartQuest();
        switch (state)
        {
            case QuestState.IN_PROGRESS:
                break;
            case QuestState.COMPLETE:
                questList.Remove(currentQuest);
                questUIController.RemoveQuestUI(currentQuest);
                currentQuest.CompleteQuest();   
                currentQuest = null;
                break;
        }
    }

    public void TrackQuest(Quest quest)
    {
        currentQuest = quest;
        quest.SetQuestState(QuestState.IN_PROGRESS);
        questUIController.SetGeneralQuestName(quest);
    }

    public void ReceiveQuest(Quest quest)
    {
        if (currentQuest == null) {
            currentQuest = quest;
            questUIController.SetGeneralQuestName(quest);
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
