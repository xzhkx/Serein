using UnityEngine;
using UnityEngine.UIElements;

public class QuestUIController : MonoBehaviour
{
    private QuestManager questManager;
    private QuestUIModel questUIModel;

    private Button currentButton;

    private void Awake()
    {
        questManager = GetComponent<QuestManager>();
        questUIModel = GetComponent<QuestUIModel>();
    }

    public void CreateNewQuestUI(Quest quest)
    {
        Button button = questUIModel.AddQuestInfoButton(quest);
        button.RegisterCallback<ClickEvent>(OnSetQuestInfo);
    }

    public void SetGeneralQuestName(Quest quest)
    {
        questUIModel.SetGeneralQuestName(quest);
    }

    private void OnSetQuestInfo(ClickEvent clickEvent)
    {
        currentButton = clickEvent.target as Button;
        questUIModel.SetQuestInfo(currentButton);
    }
}
