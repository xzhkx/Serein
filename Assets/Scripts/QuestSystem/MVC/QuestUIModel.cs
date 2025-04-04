using UnityEngine;
using UnityEngine.UIElements;

using System.Collections.Generic;
using System.Collections;

public class QuestUIModel : MonoBehaviour
{
    [SerializeField] 
    private UIDocument questUIDocument, animationUIDocument, generalUIDocument;

    private VisualElement questPanel, questIconDisplay, questTargetIcon;
    private TextElement questName, questDescription, generalQuestName;

    private Button closeQuestPanelButton;

    private Queue<Button> questInfoButtons = new Queue<Button>(10);
    private Dictionary<Button, Quest> buttonInfoDictionary = new Dictionary<Button, Quest>(10);
    private Dictionary<Quest, Button> questButtonDictionary = new Dictionary<Quest, Button>(10);

    private void Awake()
    {
        SetUpUI();

        List<Button> buttons = questUIDocument.rootVisualElement.Query<Button>("QuestInfoButton").ToList(); 
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].style.display = DisplayStyle.None;
            questInfoButtons.Enqueue(buttons[i]);
        }
    }

    public Button AddQuestInfoButton(Quest quest)
    {
        Button button = questInfoButtons.Dequeue();

        button.style.display = DisplayStyle.Flex;
        button.text = quest.questName;

        buttonInfoDictionary.Add(button, quest);
        questButtonDictionary.Add(quest, button);

        StartCoroutine(ReceiveQuestAnimation());

        return button;
    }

    public void SetQuestInfo(Button questButton)
    {
        Quest quest = buttonInfoDictionary[questButton];
        questName.text = quest.questName;
        questDescription.text = quest.questDescription;
    }

    public void SetGeneralQuestName(Quest quest)
    {
        generalQuestName.text = quest.questName;
    }

    public void RemoveQuestInfo(Quest quest)
    {
        Button button = questButtonDictionary[quest];
        button.style.display = DisplayStyle.None;

        questName.text = string.Empty;
        questDescription.text = string.Empty;

        questButtonDictionary.Remove(quest);
        buttonInfoDictionary.Remove(button);
        questInfoButtons.Enqueue(button);
    }

    private IEnumerator ReceiveQuestAnimation()
    {
        questIconDisplay.AddToClassList("quest-fade-in");
        yield return new WaitForSeconds(5);
        questIconDisplay.RemoveFromClassList("quest-fade-in");
    }

    private void OnCloseQuestPanel(ClickEvent clickEvent)
    {
        questPanel.style.display = DisplayStyle.None;
    }

    private void SetUpUI()
    {
        questIconDisplay = animationUIDocument.rootVisualElement.Q<VisualElement>("QuestIconDisplay");
        generalQuestName = generalUIDocument.rootVisualElement.Q<TextElement>("QuestName");

        closeQuestPanelButton = questUIDocument.rootVisualElement.Q<Button>("CloseButton");
        closeQuestPanelButton.RegisterCallback<ClickEvent>(OnCloseQuestPanel);

        questPanel = questUIDocument.rootVisualElement.Q<VisualElement>("QuestSystemPanel");
        questName = questUIDocument.rootVisualElement.Q<TextElement>("QuestName");
        questDescription = questUIDocument.rootVisualElement.Q<TextElement>("QuestDescription");
    }
}
