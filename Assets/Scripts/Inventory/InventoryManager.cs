using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] 
    private List<ItemScriptableObject> itemReferences = new List<ItemScriptableObject>();

    private InventoryPresenter inventoryPresenter;
    private Dictionary<int, Item> inventoryItems = new Dictionary<int, Item>(100);

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
        Debug.Log(inventoryItems[itemID].GetItemQuantity());
        inventoryPresenter.AddItem(inventoryItems[itemID], inventoryItems[itemID].GetItemQuantity());
    }

    public bool RemoveItem(int itemID, int quantity) 
    {
        if(inventoryItems.ContainsKey(itemID)
        && inventoryItems[itemID].GetItemQuantity() >= quantity){
            inventoryItems[itemID].DecreaseQuantity(quantity);

            inventoryPresenter.RemoveItem(inventoryItems[itemID], inventoryItems[itemID].GetItemQuantity());
            return true;
        } return false;
    }

    public int GetItemQuantity(int itemID)
    {
        return inventoryItems[itemID].GetItemQuantity();
    }
}
