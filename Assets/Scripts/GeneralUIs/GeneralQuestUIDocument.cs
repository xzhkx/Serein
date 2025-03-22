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
        questPanel.visible = false;

        openQuestPanelButton = generalUIDocument.rootVisualElement.Q<Button>("OpenQuestPanelButton");
        openQuestPanelButton.RegisterCallback<ClickEvent>(OnOpenQuestPanel);
    }

    private void OnOpenQuestPanel(ClickEvent clickEvent)
    {
        questPanel.visible = !questPanel.visible;
    }
}
