using System;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class GeneralPresenter : MonoBehaviour
{
    [SerializeField] 
    private UIDocument generalUIDocument;

    [SerializeField] 
    private UIDocument questUIDocument;

    [SerializeField] 
    private UIDocument inventoryUIDocument;

    [SerializeField] 
    private UIDocument statsUIDocument;

    private VisualElement generalPanel, questPanel, inventoryPanel, statsPanel;
    private Button openQuestPanelButton, openInventoryButton, openStatsButton;

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

    public void SetUndetermineDistance()
    {
        distanceText.Clear();
        distanceText.Append("Undetermine");
        targetDistance.text = distanceText.ToString();
    }

    public void ClearGeneralQuest()
    {
        targetDistance.text = string.Empty;
        generalQuestName.text = string.Empty;
    }

    public void EnableFunctionalityButton(int functionalityID)
    {
        switch(functionalityID)
        {
            case 0:
                openInventoryButton.style.display = DisplayStyle.Flex;
                break;
            case 1:
                openQuestPanelButton.style.display = DisplayStyle.Flex;
                break;
            case 2:
                openStatsButton.style.display = DisplayStyle.Flex;
                break;
        }    
    }

    public void DisableGeneralButtons()
    {
        openQuestPanelButton.style.display = DisplayStyle.None;
        openInventoryButton.style.display = DisplayStyle.None;
        openStatsButton.style.display = DisplayStyle.None;
    }

    public void EnableGeneralUI()
    {
        BlurManager.Instance.DisableBlur();
        DialogueManager.Instance.EnablePlayerAction();
        generalPanel.style.display = DisplayStyle.Flex;
    }

    private void OpenQuestPanel(ClickEvent clickEvent)
    {
        questPanel.visible = true;
        questPanel.style.display = DisplayStyle.Flex;
        DisableGeneralUI();
    }

    private void OpenInventoryPanel(ClickEvent clickEvent)
    {
        inventoryPanel.visible = true;
        inventoryPanel.style.display = DisplayStyle.Flex;
        DisableGeneralUI();
    }

    private void DisableGeneralUI()
    {
        BlurManager.Instance.EnableBlur();
        DialogueManager.Instance.FreezePlayerAction();
        generalPanel.style.display = DisplayStyle.None; 
    }

    private void SetUpUI()
    {
        questPanel = questUIDocument.rootVisualElement.Q<VisualElement>("QuestSystemPanel");
        questPanel.style.display = DisplayStyle.None;
        questPanel.visible = false;

        openQuestPanelButton = generalUIDocument.rootVisualElement.Q<Button>("OpenQuestPanelButton");
        openQuestPanelButton.RegisterCallback<ClickEvent>(OpenQuestPanel);
        generalQuestName = generalUIDocument.rootVisualElement.Q<TextElement>("QuestName");
        targetDistance = generalUIDocument.rootVisualElement.Q<TextElement>("TargetDistance");

        generalPanel = generalUIDocument.rootVisualElement.Q<VisualElement>("GeneralPanel");

        inventoryPanel = inventoryUIDocument.rootVisualElement.Q<VisualElement>("InventoryPanel");
        inventoryPanel.style.display = DisplayStyle.None;
        inventoryPanel.visible = false;

        openInventoryButton = generalUIDocument.rootVisualElement.Q<Button>("OpenInventoryButton");
        openInventoryButton.RegisterCallback<ClickEvent>(OpenInventoryPanel);

        openStatsButton = generalUIDocument.rootVisualElement.Q<Button>("OpenStatsButton");
    }
}
