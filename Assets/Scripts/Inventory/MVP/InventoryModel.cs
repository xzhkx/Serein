using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class InventoryModel : MonoBehaviour
{
    private Dictionary<Button, Item> buttonItemDictionary = new Dictionary<Button, Item>();
    private Dictionary<Item, Button> itemButtonDictionary = new Dictionary<Item, Button>();

    public void AddItem(Button button, Item item)
    {
        buttonItemDictionary.Add(button, item);
        itemButtonDictionary.Add(item, button);
    }

    public Item GetItem(Button button)
    {
        return buttonItemDictionary[button];
    }

    public Button GetButton(Item item)
    {
        return itemButtonDictionary[item];
    }
}
