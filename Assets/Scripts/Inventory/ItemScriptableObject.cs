using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemScriptableObject : ScriptableObject
{
    public int itemID;
    public string itemName;
    public string itemDescription;
}
