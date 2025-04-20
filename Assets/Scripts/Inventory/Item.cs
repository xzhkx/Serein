using UnityEngine;

public class Item
{
    private ItemScriptableObject itemScriptableObject;
    private int itemQuantity;

    public Item(ItemScriptableObject itemScriptableObject)
    {
        this.itemScriptableObject = itemScriptableObject;
        itemQuantity = 0;
    }

    public int GetItemQuantity()
    {
        return itemQuantity;  
    }

    public Texture2D GetItemIcon()
    {
        return itemScriptableObject.itemIcon;
    }

    public void IncreaseQuantity(int quantity)
    {
        itemQuantity += quantity;
    }

    public void DecreaseQuantity(int quantity)
    { 
        itemQuantity -= quantity;   
    }
}
