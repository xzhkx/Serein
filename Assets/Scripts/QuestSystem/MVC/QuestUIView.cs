using UnityEngine;
using UnityEngine.UIElements;

public class QuestUIView : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement questPanel;
    private TextElement questName, questDescription;
    private Button openQuestInfoButton;


    private void Start()
    {
        questPanel = uiDocument.rootVisualElement.Q<VisualElement>("QuestPanel");
        //questPanel.visible = false;

        questName = uiDocument.rootVisualElement.Q<TextElement>("QuestName");
        questDescription = uiDocument.rootVisualElement.Q<TextElement>("QuestDescription");
        openQuestInfoButton = uiDocument.rootVisualElement.Q<Button>("QuestInfoButton");
        openQuestInfoButton.RegisterCallback<ClickEvent>(SetQuestInfo);
    }

    private void OpenQuestPanel()
    {
        questPanel.visible = true;
    }

    public Button GetOpenQuestInfoButton()
    {
        return uiDocument.rootVisualElement.Q<Button>("QuestInfoButton");
    }

    private void SetQuestInfo(ClickEvent clickEvent)
    {
        Debug.Log("Clicked");
        //SetQuestInfoA(GetComponent<QuestManager>().GetCurrentQuest());
    }

    public void SetQuestInfoA(Quest currentQuest)
    {
        questName.text = currentQuest.questName;
        openQuestInfoButton.text = currentQuest.questName;
        questDescription.text = currentQuest.questDescription;
    }
}
