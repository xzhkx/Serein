using UnityEngine;

public class CQ_ReceiveItem : MonoBehaviour, ICompleteQuest
{
    [SerializeField]
    private int itemID, itemQuantity;

    public void MakeAction()
    {
        InventoryManager.Instance.AddItem(itemID, itemQuantity);
    }
}
