public class Item
{
    private ItemScriptableObject itemScriptableObject;
    private int itemQuantity;

    public Item(ItemScriptableObject itemScriptableObject)
    {
        this.itemScriptableObject = itemScriptableObject;
        itemQuantity = 0;
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
