using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryPresenter : MonoBehaviour
{
    [SerializeField]
    private UIDocument generalUIDocument, inventoryUIDocument;

    private VisualElement generalPanel, inventoryPanel;
    private Button closeInventoryPanelButton;

    private VisualElement itemBigIcon;
    private TextElement itemDescription, itemName;

    private Queue<Button> buttonsQueue = new Queue<Button>(30);

    private InventoryModel inventoryModel;

    private void Awake()
    {
        SetUpUI();
    }

    private void Start()
    {
        inventoryModel = GetComponent<InventoryModel>();
        generalPanel = generalUIDocument.rootVisualElement.Q<VisualElement>("GeneralPanel");
    }

    public void AddItem(Item item, int quantity)
    {
        inventoryPanel.visible = true;
        if (inventoryModel.ExistItem(item))
        {
            inventoryModel.GetButton(item).Q<TextElement>("ItemQuantity").text = quantity.ToString();
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
        Item item = inventoryModel.GetItem(clickEvent.target as Button);

        itemName.text = item.GetItemName();
        itemDescription.text = item.GetItemDescription();
        itemBigIcon.style.backgroundImage = item.GetItemBigIcon();
    }

    private void CloseInventoryPanel(ClickEvent clickEvent)
    {
        BlurManager.Instance.DisableBlur();
        DialogueManager.Instance.EnablePlayerAction();

        generalPanel.style.display = DisplayStyle.Flex;
        inventoryPanel.style.display = DisplayStyle.None;

        itemBigIcon.style.backgroundImage = null;
        itemName.text = string.Empty;
        itemDescription.text = string.Empty;    

        inventoryPanel.visible = false;
    }

    private void SetUpUI()
    {
        inventoryPanel = inventoryUIDocument.rootVisualElement.Q<VisualElement>("InventoryPanel");

        closeInventoryPanelButton = inventoryUIDocument.
            rootVisualElement.Q<Button>("CloseButton");
        closeInventoryPanelButton.RegisterCallback<ClickEvent>(CloseInventoryPanel);

        itemBigIcon = inventoryUIDocument.rootVisualElement.Q<VisualElement>("ItemBigIcon");
        itemDescription = inventoryUIDocument.rootVisualElement.Q<TextElement>("ItemDescription");
        itemName = inventoryUIDocument.rootVisualElement.Q<TextElement>("ItemName");

        itemBigIcon.style.backgroundImage = null;
        itemName.text = string.Empty;
        itemDescription.text = string.Empty;

        List<Button> buttons = inventoryUIDocument.rootVisualElement.Query<Button>("ItemButton").ToList();
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].style.display = DisplayStyle.None;
            buttonsQueue.Enqueue(buttons[i]);
        }
    }
}
