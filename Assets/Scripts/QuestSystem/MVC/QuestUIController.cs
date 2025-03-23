using UnityEngine;
using UnityEngine.UIElements;

public class QuestUIController : MonoBehaviour
{
    private QuestManager questManager;
    private QuestUIModel questUIModel;

    private Quest currentQuest;

    private void Awake()
    {
        questManager = GetComponent<QuestManager>();
        questUIModel = GetComponent<QuestUIModel>();
    }

    public void CreateNewQuestUI(Quest quest)
    {
        currentQuest = quest;
        Button button = questUIModel.AddQuestInfoButton(quest);
        button.RegisterCallback<ClickEvent>(OnSetQuestInfo);
    }


    private void OnSetQuestInfo(ClickEvent clickEvent)
    {
        questUIModel.SetQuestInfo(currentQuest);
    }
}
