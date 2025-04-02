using UnityEngine;
using UnityEngine.UIElements;

using System.Collections.Generic;
using System.Collections;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField]
    private UIDocument inventoryUIDocument;

    private VisualElement inventoryPanel;
    private Button closeInventoryPanelButton;

    private void Awake()
    {
        inventoryPanel = inventoryUIDocument.rootVisualElement.Q<VisualElement>("InventoryPanel");
        closeInventoryPanelButton = inventoryUIDocument.
            rootVisualElement.Q<Button>("CloseButton");
        closeInventoryPanelButton.RegisterCallback<ClickEvent>(OnCloseInventoryPanel);
    }

    private void OnCloseInventoryPanel(ClickEvent clickEvent)
    {
        inventoryPanel.style.display = DisplayStyle.None;
    }
}
