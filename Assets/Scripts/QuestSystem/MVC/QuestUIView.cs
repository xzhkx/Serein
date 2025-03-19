using UnityEngine;
using UnityEngine.UIElements;

public class QuestUIView : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement questPanel;
    private TextElement questName, questDescription;
    private Button openQuestInfoButton;

    private void Awake()
    {
        questPanel = uiDocument.rootVisualElement.Q<VisualElement>("QuestPanel");
        questName = uiDocument.rootVisualElement.Q<TextElement>("QuestName");
        questDescription = uiDocument.rootVisualElement.Q<TextElement>("QuestDescription");
        openQuestInfoButton = uiDocument.rootVisualElement.Q<Button>("QuestInfoButton");
    }

    public Button GetOpenQuestInfoButton()
    {
        return openQuestInfoButton;
    }

    public void SetQuestInfo(Quest currentQuest)
    {
        questName.text = currentQuest.questName;
        openQuestInfoButton.text = currentQuest.questName;
        questDescription.text = currentQuest.questDescription;
    }
}
