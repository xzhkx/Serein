using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemScriptableObject : ScriptableObject
{
    public int itemID;
    public int itemName;
    public string itemDescription;
}
