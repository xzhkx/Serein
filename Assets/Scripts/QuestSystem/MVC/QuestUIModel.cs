using UnityEngine;
using UnityEngine.UIElements;

public class QuestUIModel : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement questPanel;
    private TextElement questName, questDescription;
    private Button questInfoButton;

    private void Awake()
    {
        questPanel = uiDocument.rootVisualElement.Q<VisualElement>("QuestPanel");
        questName = uiDocument.rootVisualElement.Q<TextElement>("QuestName");
        questDescription = uiDocument.rootVisualElement.Q<TextElement>("QuestDescription");
        questInfoButton = uiDocument.rootVisualElement.Q<Button>("QuestInfoButton");
    }

    public Button GetQuestInfoButton()
    {
        return questInfoButton;
    }

    public void SetQuestInfo(Quest currentQuest)
    {
        Debug.Log("Set");
        questName.text = currentQuest.questName;
        questInfoButton.text = currentQuest.questName;
        questDescription.text = currentQuest.questDescription;
    }
}
