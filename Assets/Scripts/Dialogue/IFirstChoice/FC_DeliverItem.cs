using UnityEngine;

public class FC_DeliverItem : MonoBehaviour, IFirstChoice
{
    [SerializeField]
    private int itemID, quantity;

    public void MakeAction()
    {
        InventoryManager.Instance.RemoveItem(itemID, quantity);
    }
}
