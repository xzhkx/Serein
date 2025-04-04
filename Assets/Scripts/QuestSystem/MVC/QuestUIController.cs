using UnityEngine;
using UnityEngine.UIElements;

public class QuestUIController : MonoBehaviour
{
    private QuestUIModel questUIModel;
    private Button currentButton;

    private void Awake()
    {
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

    public void RemoveQuestUI(Quest quest)
    {
        questUIModel.RemoveQuestInfo(quest);
    }

    private void OnSetQuestInfo(ClickEvent clickEvent)
    {
        currentButton = clickEvent.target as Button;
        questUIModel.SetQuestInfo(currentButton);
    }
}
