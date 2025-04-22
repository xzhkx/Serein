using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryPresenter : MonoBehaviour
{
    [SerializeField]
    private UIDocument inventoryUIDocument;

    private VisualElement inventoryPanel;
    private Button closeInventoryPanelButton;

    private VisualElement itemVisual;
    private TextElement itemDescription, itemName;

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

    public void AddItem(Item item, int quantity)
    {
        inventoryPanel.visible = true;
        if (inventoryModel.ExistItem(item))
        {
            Button button = inventoryModel.GetButton(item);
            button.Q<TextElement>("ItemQuantity").text = quantity.ToString();
        }

        else
        {
            Button button = buttonsQueue.Dequeue();
            button.RegisterCallback<ClickEvent>(SelectItem);

            button.style.display = DisplayStyle.Flex;
            button.style.backgroundImage = item.GetItemIcon();

            inventoryModel.AddItem(button, item);
        }
     
        inventoryPanel.visible = false;
    }

    public void RemoveItem(Item item, int currentQuantity)
    {
        if(currentQuantity <= 0)
        {
            Button button = inventoryModel.GetButton(item);
            button.style.display = DisplayStyle.None;
            buttonsQueue.Enqueue(button);
        }
        else
        {
            Button button = inventoryModel.GetButton(item);
            button.Q<TextElement>("ItemQuantity").text = currentQuantity.ToString();
        }
    }

    private void SelectItem(ClickEvent clickEvent)
    {
        Button button = clickEvent.target as Button;
        Item item = inventoryModel.GetItem(button);

        itemName.text = item.GetItemName();
        itemDescription.text = item.GetItemDescription();
    }

    private void CloseInventoryPanel(ClickEvent clickEvent)
    {
        inventoryPanel.style.display = DisplayStyle.None;
        inventoryPanel.visible = false;
    }

    private void SetUpUI()
    {
        inventoryPanel = inventoryUIDocument.rootVisualElement.Q<VisualElement>("InventoryPanel");

        closeInventoryPanelButton = inventoryUIDocument.
            rootVisualElement.Q<Button>("CloseButton");
        closeInventoryPanelButton.RegisterCallback<ClickEvent>(CloseInventoryPanel);

        itemVisual = inventoryUIDocument.rootVisualElement.Q<VisualElement>("ItemVisual");
        itemDescription = inventoryUIDocument.rootVisualElement.Q<TextElement>("ItemDescription");
        itemName = inventoryUIDocument.rootVisualElement.Q<TextElement>("ItemName");

        List<Button> buttons = inventoryUIDocument.rootVisualElement.Query<Button>("ItemButton").ToList();
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].style.display = DisplayStyle.None;
            buttonsQueue.Enqueue(buttons[i]);
        }
    }
}
