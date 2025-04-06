using UnityEngine;

public class CollectItemModel : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private int currentItemID;

    private void Start()
    {
        inventoryManager = InventoryManager.Instance;
    }

    public void CollectItem()
    {
        inventoryManager.AddItem(currentItemID, 1);
    }

    public void SetCurrentItemID(int itemID)
    {
        currentItemID = itemID; 
    }
}
