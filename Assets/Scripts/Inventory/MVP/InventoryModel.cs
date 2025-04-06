using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class InventoryModel : MonoBehaviour
{
    private Dictionary<Button, Item> buttonItemDictionary = new Dictionary<Button, Item>();

    public void AddItem(Button button, Item item)
    {
        buttonItemDictionary.Add(button, item);
    }
}
