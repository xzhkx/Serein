using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class QuestPresenter : MonoBehaviour
{
    [SerializeField]
    private UIDocument questUIDocument, animationUIDocument;

    private VisualElement questPanel, questIconDisplay, questTargetIcon;
    private TextElement questName, questDescription;

    private Button closeQuestPanelButton;

    private Queue<Button> buttonsQueue = new Queue<Button>(10);

    private QuestModel questModel;

    private void Awake()
    {
        SetUpUI();
    }

    private void Start()
    {
        questModel = GetComponent<QuestModel>();
    }

    private void OnSetQuest(ClickEvent clickEvent)
    {
        Button button = clickEvent.target as Button;
        Quest quest = questModel.GetQuest(button);

        questName.text = quest.GetQuestName();
        questDescription.text = quest.GetQuestDescription();
    }

    public void CreateNewQuest(Quest quest)
    {
        Button button = buttonsQueue.Dequeue();
        button.RegisterCallback<ClickEvent>(OnSetQuest);

        button.style.display = DisplayStyle.Flex;
        button.text = quest.GetQuestName();

        questModel.CreateNewQuest(button, quest);
        StartCoroutine(ReceiveQuestAnimation());
    }

    public void RemoveQuest(Quest quest)
    {
        Button button = questModel.GetButton(quest);
        button.style.display = DisplayStyle.None;

        questName.text = string.Empty;
        questDescription.text = string.Empty;

        questModel.RemoveQuest(button, quest);
        buttonsQueue.Enqueue(button);
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

        closeQuestPanelButton = questUIDocument.rootVisualElement.Q<Button>("CloseButton");
        closeQuestPanelButton.RegisterCallback<ClickEvent>(OnCloseQuestPanel);

        questPanel = questUIDocument.rootVisualElement.Q<VisualElement>("QuestSystemPanel");
        questName = questUIDocument.rootVisualElement.Q<TextElement>("QuestName");
        questDescription = questUIDocument.rootVisualElement.Q<TextElement>("QuestDescription");

        List<Button> buttons = questUIDocument.rootVisualElement.Query<Button>("QuestInfoButton").ToList();
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].style.display = DisplayStyle.None;
            buttonsQueue.Enqueue(buttons[i]);
        }
    }
}
