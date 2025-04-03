using UnityEngine;
using UnityEngine.UIElements;

public class CollectItemUIController : MonoBehaviour
{
    public static CollectItemUIController Instance;

    public int currentItemID;

    private InventoryManager inventoryManager;
    private CollectItemUIModel collectItemUIModel;
    private Button collectItemButton;

    private void Awake()
    {
        Instance = this;
        inventoryManager = GetComponent<InventoryManager>();
        collectItemUIModel = GetComponent<CollectItemUIModel>();
    }

    private void Start()
    {
        collectItemButton = collectItemUIModel.GetCollectItemButton();
        collectItemButton.RegisterCallback<ClickEvent>(CollectItem);
    }

    public void CollectItem(ClickEvent clickEvent)
    {
        collectItemUIModel.DisableCollectItemButton();
        inventoryManager.AddItem(currentItemID, 1);
    }

    public void DisplayCollectItemButton()
    {
        collectItemUIModel.DisplayCollectItemButton();
    }

    public void DisableCollectItemButton()
    {
        collectItemUIModel.DisableCollectItemButton();
    }
}
