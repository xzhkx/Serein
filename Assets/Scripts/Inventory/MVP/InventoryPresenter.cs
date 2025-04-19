using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryPresenter : MonoBehaviour
{
    [SerializeField]
    private UIDocument inventoryUIDocument;

    private VisualElement inventoryPanel;
    private Button closeInventoryPanelButton;

    private Queue<Button> buttonsQueue = new Queue<Button>(15);

    private InventoryModel inventoryModel;

    private void Awake()
    {
        SetUpUI();
    }

    private void Start()
    {
        inventoryModel = GetComponent<InventoryModel>();
    }

    public void AddItem(Item item)
    {
        Button button = buttonsQueue.Dequeue();
        button.style.display = DisplayStyle.Flex;

        //-> Load Image BG
        inventoryModel.AddItem(button, item);
    }

    private void OnCloseInventoryPanel(ClickEvent clickEvent)
    {
        inventoryPanel.style.display = DisplayStyle.None;
        inventoryPanel.visible = false;
    }

    private void SetUpUI()
    {
        inventoryPanel = inventoryUIDocument.rootVisualElement.Q<VisualElement>("InventoryPanel");

        closeInventoryPanelButton = inventoryUIDocument.
            rootVisualElement.Q<Button>("CloseButton");
        closeInventoryPanelButton.RegisterCallback<ClickEvent>(OnCloseInventoryPanel);

        List<Button> buttons = inventoryUIDocument.rootVisualElement.Query<Button>("ItemButton").ToList();
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].style.display = DisplayStyle.None;
            buttonsQueue.Enqueue(buttons[i]);
        }
    }
}
