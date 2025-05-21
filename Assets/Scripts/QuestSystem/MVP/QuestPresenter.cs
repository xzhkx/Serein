using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestPresenter : MonoBehaviour
{
    [SerializeField]
    private UIDocument generalUIDocument, questUIDocument, questIconDisplayUIDocument;

    private VisualElement generalPanel, questPanel, questIcon, questIconPanel;
    private TextElement questName, questDescription, questIconName;

    private Button closeQuestPanelButton, trackButton;

    private Queue<Button> buttonsQueue = new Queue<Button>(10);
    private QuestModel questModel;

    private Quest selectedQuest;

    private WaitForSeconds waitForSeconds1;
    private WaitForSeconds waitForSeconds5;

    private void Awake()
    {
        SetUpUI();

        waitForSeconds1 = new WaitForSeconds(1);
        waitForSeconds5 = new WaitForSeconds(5f);
    }

    private void Start()
    {
        questModel = GetComponent<QuestModel>();
        generalPanel = generalUIDocument.rootVisualElement.Q<VisualElement>("GeneralPanel");
    }

    private void OnSetQuest(ClickEvent clickEvent)
    {
        Button button = clickEvent.target as Button;
        Quest quest = questModel.GetQuest(button);

        questName.text = quest.GetQuestName();
        questDescription.text = quest.GetQuestDescription();

        selectedQuest = quest;
    }

    public Quest GetSelectedQuest()
    {
        return selectedQuest;
    }

    public Button GetTrackButton()
    {
        return trackButton;
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

        questModel.GetButton(quest).style.display = DisplayStyle.None;

        questName.text = string.Empty;
        questDescription.text = string.Empty;

        questModel.RemoveQuest(questModel.GetButton(quest), quest);
        buttonsQueue.Enqueue(questModel.GetButton(quest));
    }

    private IEnumerator ReceiveQuestAnimation(string questIconName, Texture2D questIcon)
    {
        questIconPanel.visible = true;
        this.questIcon.style.backgroundImage = questIcon;
        this.questIconName.text = questIconName;

        yield return waitForSeconds1;
        questIconPanel.AddToClassList("quest-panel-fade-in");
        yield return waitForSeconds5;
        questIconPanel.RemoveFromClassList("quest-panel-fade-in");
        yield return waitForSeconds1;
        questIconPanel.visible = false;
    }

    private void OnCloseQuestPanel(ClickEvent clickEvent)
    {
        questPanel.style.display = DisplayStyle.None;
        questPanel.visible = false;

        generalPanel.style.display = DisplayStyle.Flex;
        BlurManager.Instance.DisableBlur();
        DialogueManager.Instance.EnablePlayerAction();

    }

    private void SetUpUI()
    {
        questIcon = questIconDisplayUIDocument.rootVisualElement.Q<VisualElement>("QuestIcon");
        questIconPanel = questIconDisplayUIDocument.rootVisualElement.Q<VisualElement>("QuestIconPanel");
        questIconName = questIconDisplayUIDocument.rootVisualElement.Q<TextElement>("QuestName");

        closeQuestPanelButton = questUIDocument.rootVisualElement.Q<Button>("CloseButton");
        closeQuestPanelButton.RegisterCallback<ClickEvent>(OnCloseQuestPanel);
        trackButton = questUIDocument.rootVisualElement.Q<Button>("TrackButton");

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
