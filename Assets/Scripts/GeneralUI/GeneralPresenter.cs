using System;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class GeneralPresenter : MonoBehaviour
{
    [SerializeField] private UIDocument generalUIDocument;
    [SerializeField] private UIDocument questUIDocument;
    [SerializeField] private UIDocument inventoryUIDocument;

    private VisualElement questPanel, inventoryPanel;
    private Button openQuestPanelButton, openInventoryButton;

    private TextElement generalQuestName, targetDistance;

    private StringBuilder distanceText;

    private void Start()
    {
        SetUpUI();
        DisableGeneralButtons();
        SetGeneralQuestName(string.Empty);

        distanceText = new StringBuilder(6);
    }

    public void SetGeneralQuestName(string questName)
    {
        generalQuestName.text = questName;  
    }

    public void SetTargetDistance(float distance)
    {
        distanceText.Clear();
        distanceText.Append(Math.Round(distance));
        distanceText.Append('m');
        targetDistance.text = distanceText.ToString();
    }

    public void ClearGeneralQuest()
    {
        targetDistance.text = string.Empty;
        generalQuestName.text += string.Empty;
    }

    private void OnOpenQuestPanel(ClickEvent clickEvent)
    {
        questPanel.style.display = DisplayStyle.Flex;
    }

    private void OnOpenInventoryPanel(ClickEvent clickEvent)
    {
        inventoryPanel.style.display = DisplayStyle.Flex;
    }

    public void EnableGeneralButtons()
    {
        openQuestPanelButton.style.display = DisplayStyle.Flex;
        openInventoryButton.style.display = DisplayStyle.Flex;
    }

    public void DisableGeneralButtons()
    {
        openQuestPanelButton.style.display = DisplayStyle.None;
        openInventoryButton.style.display = DisplayStyle.None;
    }

    private void SetUpUI()
    {
        questPanel = questUIDocument.rootVisualElement.Q<VisualElement>("QuestSystemPanel");
        questPanel.style.display = DisplayStyle.None;

        openQuestPanelButton = generalUIDocument.rootVisualElement.Q<Button>("OpenQuestPanelButton");
        openQuestPanelButton.RegisterCallback<ClickEvent>(OnOpenQuestPanel);
        generalQuestName = generalUIDocument.rootVisualElement.Q<TextElement>("QuestName");
        targetDistance = generalUIDocument.rootVisualElement.Q<TextElement>("TargetDistance");

        inventoryPanel = inventoryUIDocument.rootVisualElement.Q<VisualElement>("InventoryPanel");
        inventoryPanel.style.display = DisplayStyle.None;

        openInventoryButton = generalUIDocument.rootVisualElement.Q<Button>("OpenInventoryButton");
        openInventoryButton.RegisterCallback<ClickEvent>(OnOpenInventoryPanel);
    }
}
