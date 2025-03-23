using UnityEngine;
using UnityEngine.UIElements;

public class GeneralQuestUIDocument : MonoBehaviour
{
    [SerializeField] private UIDocument generalUIDocument;
    [SerializeField] private UIDocument questUIDocument;

    private VisualElement questPanel;

    private Button openQuestPanelButton;

    private void Start()
    {
        questPanel = questUIDocument.rootVisualElement.Q<VisualElement>("QuestPanel");
        questPanel.style.display = DisplayStyle.None;

        openQuestPanelButton = generalUIDocument.rootVisualElement.Q<Button>("OpenQuestPanelButton");
        openQuestPanelButton.RegisterCallback<ClickEvent>(OnOpenQuestPanel);
    }

    private void OnOpenQuestPanel(ClickEvent clickEvent)
    {
        if (questPanel.style.display != DisplayStyle.None) 
        {
            questPanel.style.display = DisplayStyle.None;
        } else questPanel.style.display = DisplayStyle.Flex;
    }
}
