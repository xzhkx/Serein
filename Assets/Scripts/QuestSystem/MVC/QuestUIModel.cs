using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class QuestUIModel : MonoBehaviour
{
    [SerializeField] 
    private UIDocument uiDocument;

    private VisualElement questPanel;
    private TextElement questName, questDescription;

    private Queue<Button> questInfoButtons = new Queue<Button>(10);
    private Dictionary<Button, Quest> buttonInfoDictionary = new Dictionary<Button, Quest>(10);

    private void Awake()
    {
        questPanel = uiDocument.rootVisualElement.Q<VisualElement>("QuestPanel");
        questName = uiDocument.rootVisualElement.Q<TextElement>("QuestName");
        questDescription = uiDocument.rootVisualElement.Q<TextElement>("QuestDescription");

        List<Button> buttons = uiDocument.rootVisualElement.Query<Button>("QuestInfoButton").ToList(); 
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
        return button;
    }


    public void SetQuestInfo(Quest quest)
    {
        questName.text = quest.questName;
        questDescription.text = quest.questDescription;
    }
}
