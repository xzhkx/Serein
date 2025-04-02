using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private Dictionary<int, int> inventoryItems = new Dictionary<int, int>(10);

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < 10; i++) {
            inventoryItems.Add(i, 0);
        }
    }
    public void AddItem(int itemID, int quantity)
    {
        inventoryItems[itemID] = inventoryItems[itemID] + quantity;
    }

    public void RemoveItem(int itemID, int quantity) 
    {
        int value = inventoryItems[itemID];
        value -= quantity;
        inventoryItems[itemID] = value;
    }
}
