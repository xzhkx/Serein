using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject itemScriptableObject;
    [SerializeField] private int itemQuantity;

    public void IncreaseQuantity(int quantity)
    {
        itemQuantity += quantity;
    }

    public void DecreaseQuantity(int quantity)
    { 
        itemQuantity -= quantity;   
    }
}
