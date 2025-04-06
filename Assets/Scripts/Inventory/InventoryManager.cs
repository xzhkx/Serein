using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] 
    private List<ItemScriptableObject> itemReferences = new List<ItemScriptableObject>();

    private InventoryPresenter inventoryPresenter;
    private Dictionary<int, Item> inventoryItems = new Dictionary<int, Item>(10);

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < itemReferences.Count; i++) {
            Item item = new Item(itemReferences[i]);
            inventoryItems.Add(itemReferences[i].itemID, item);
        }

        inventoryPresenter = GetComponent<InventoryPresenter>();
    }

    public void AddItem(int itemID, int quantity)
    {
        inventoryItems[itemID].IncreaseQuantity(quantity);
        inventoryPresenter.AddItem(inventoryItems[itemID]);
    }

    public void RemoveItem(int itemID, int quantity) 
    {
        inventoryItems[itemID].DecreaseQuantity(quantity);
    }

    public int GetItemQuantity(int itemID)
    {
        return inventoryItems[itemID].GetItemQuantity();
    }
}
