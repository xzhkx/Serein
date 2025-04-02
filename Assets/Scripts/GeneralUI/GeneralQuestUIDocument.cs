using UnityEngine;
using UnityEngine.UIElements;

public class GeneralQuestUIDocument : MonoBehaviour
{
    [SerializeField] private UIDocument generalUIDocument;
    [SerializeField] private UIDocument questUIDocument;
    [SerializeField] private UIDocument inventoryUIDocument;

    private VisualElement questPanel;
    private Button openQuestPanelButton;

    private VisualElement inventoryPanel;
    private Button openInventoryButton;

    private void Start()
    {
        questPanel = questUIDocument.rootVisualElement.Q<VisualElement>("QuestSystemPanel");
        questPanel.style.display = DisplayStyle.None;

        openQuestPanelButton = generalUIDocument.rootVisualElement.Q<Button>("OpenQuestPanelButton");
        openQuestPanelButton.RegisterCallback<ClickEvent>(OnOpenQuestPanel);

        inventoryPanel = inventoryUIDocument.rootVisualElement.Q<VisualElement>("InventoryPanel");
        inventoryPanel.style.display = DisplayStyle.None;

        openInventoryButton = generalUIDocument.rootVisualElement.Q<Button>("OpenInventoryButton");
        openInventoryButton.RegisterCallback<ClickEvent>(OnOpenInventoryPanel);
    }

    private void OnOpenQuestPanel(ClickEvent clickEvent)
    {
        questPanel.style.display = DisplayStyle.Flex; 
    }

    private void OnOpenInventoryPanel(ClickEvent clickEvent)
    {
        inventoryPanel.style.display = DisplayStyle.Flex;
    }
}
