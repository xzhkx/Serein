using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestManager : MonoBehaviour
{
    public InGameQuest inGameQuest;

    [SerializeField] private UIDocument uiDocument;

    private VisualElement questPanel;
    private TextElement questName, questInfoName, questDescription;
    public Quest currentQuest { get; private set; }
    private List<Quest> questList = new List<Quest>(10);

    private void Awake()
    {
        questPanel = uiDocument.rootVisualElement.Q<VisualElement>("QuestPanel");
        //questPanel.visible = false;

        questName = uiDocument.rootVisualElement.Q<TextElement>("QuestName");
        questInfoName = uiDocument.rootVisualElement.Q<TextElement>("QuestInfoName");
        questDescription = uiDocument.rootVisualElement.Q<TextElement>("QuestDescription");
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
            SetUIQuestInfo();
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

    private void SetUIQuestInfo()
    {
        questName.text = currentQuest.questName;
        questInfoName.text = currentQuest.questName;
        questDescription.text = currentQuest.questDescription;
    }
}
