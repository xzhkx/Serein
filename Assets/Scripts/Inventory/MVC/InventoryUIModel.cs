using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUIModel : MonoBehaviour
{
    [SerializeField]
    private UIDocument inventoryUIDocument;

    private VisualElement inventoryPanel;
    private Button closeInventoryPanelButton;

    private Queue<Button> itemButtons = new Queue<Button>(15);
    private Dictionary<Button, Item> buttonInfoDictionary = new Dictionary<Button, Item>();

    private void Awake()
    {
        inventoryPanel = inventoryUIDocument.rootVisualElement.Q<VisualElement>("InventoryPanel");

        closeInventoryPanelButton = inventoryUIDocument.
            rootVisualElement.Q<Button>("CloseButton");
        closeInventoryPanelButton.RegisterCallback<ClickEvent>(OnCloseInventoryPanel);

        List<Button> buttons = inventoryUIDocument.rootVisualElement.Query<Button>("ItemButton").ToList();
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].style.display = DisplayStyle.None;
            itemButtons.Enqueue(buttons[i]);
        }
    }

    public Button AddItemUIButton(Item item)
    {
        Button button = itemButtons.Dequeue();
        button.style.display = DisplayStyle.Flex;
        
        //-> Load Image BG
        //button.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("")); 

        buttonInfoDictionary.Add(button, item);    

        return button;
    }

    private void OnCloseInventoryPanel(ClickEvent clickEvent)
    {
        inventoryPanel.style.display = DisplayStyle.None;
    }
}
