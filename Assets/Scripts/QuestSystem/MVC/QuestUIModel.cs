using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class QuestUIModel : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement questPanel;
    private TextElement questName, questDescription;
    private List<Button> questInfoButtons;

    private void Awake()
    {
        questPanel = uiDocument.rootVisualElement.Q<VisualElement>("QuestPanel");
        questName = uiDocument.rootVisualElement.Q<TextElement>("QuestName");
        questDescription = uiDocument.rootVisualElement.Q<TextElement>("QuestDescription");
        
        for(int i = 1; i <= 6; i++)
        {
            questInfoButtons.Add(uiDocument.rootVisualElement.Q<Button>("QuestInfoButton" + i.ToString()));
        }

    }

    //public Button GetQuestInfoButton()
    //{
    //    return questInfoButton;
    //}

    //public void SetQuestInfo(Quest currentQuest)
    //{
    //    questName.text = currentQuest.questName;
    //    questInfoButton.text = currentQuest.questName;
    //    questDescription.text = currentQuest.questDescription;
    //}
}
