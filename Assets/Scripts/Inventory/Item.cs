using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject itemScriptableObject;
    [SerializeField] private int itemQuantity;


    public void AddItem(int quantity)
    {
        itemQuantity += quantity;
    }

    public void RemoveItem(int quantity)
    { 
        itemQuantity -= quantity;   
    }
}
