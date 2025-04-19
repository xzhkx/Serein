using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestPresenter : MonoBehaviour
{
    [SerializeField]
    private UIDocument questUIDocument, questIconDisplayUIDocument;

    private VisualElement questPanel, questIcon, questIconPanel;
    private TextElement questName, questDescription, questIconName;

    private Button closeQuestPanelButton;

    private Queue<Button> buttonsQueue = new Queue<Button>(10);

    private QuestModel questModel;

    private Quest selectedQuest;

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

        selectedQuest = quest; //-> Track button!
    }

    public void CreateNewQuest(Quest quest)
    {
        questPanel.visible = true;
        questPanel.style.display = DisplayStyle.None;

        Button button = buttonsQueue.Dequeue();
        button.RegisterCallback<ClickEvent>(OnSetQuest);

        button.style.display = DisplayStyle.Flex;
        button.text = quest.GetQuestName();

        questModel.CreateNewQuest(button, quest);

        if (!quest.GetQuestIconName().Equals(string.Empty))
        {
            questIconPanel.visible = true;
            questIconPanel.style.display = DisplayStyle.Flex;
            StartCoroutine(ReceiveQuestAnimation(quest.GetQuestIconName(), quest.GetQuestIcon()));
        }
    }

    public void RemoveQuest(Quest quest)
    {
        questPanel.visible = true;
        questPanel.style.display = DisplayStyle.None;

        Button button = questModel.GetButton(quest);
        button.style.display = DisplayStyle.None;

        questName.text = string.Empty;
        questDescription.text = string.Empty;

        questModel.RemoveQuest(button, quest);
        buttonsQueue.Enqueue(button);
    }

    private IEnumerator ReceiveQuestAnimation(string questIconName, Texture2D questIcon)
    {
        questIconPanel.visible = true;
        this.questIcon.style.backgroundImage = questIcon;
        this.questIconName.text = questIconName;

        yield return new WaitForSeconds(1);
        questIconPanel.AddToClassList("quest-panel-fade-in");
        yield return new WaitForSeconds(5);
        questIconPanel.RemoveFromClassList("quest-panel-fade-in");
        yield return new WaitForSeconds(1);
        questIconPanel.visible = false;
    }

    private void OnCloseQuestPanel(ClickEvent clickEvent)
    {
        questPanel.style.display = DisplayStyle.None;
        questPanel.visible = false;
    }

    private void SetUpUI()
    {
        questIcon = questIconDisplayUIDocument.rootVisualElement.Q<VisualElement>("QuestIcon");
        questIconPanel = questIconDisplayUIDocument.rootVisualElement.Q<VisualElement>("QuestIconPanel");
        questIconName = questIconDisplayUIDocument.rootVisualElement.Q<TextElement>("QuestName");

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

        questIconPanel.visible = false;
        questPanel.visible = false;
    }
}
