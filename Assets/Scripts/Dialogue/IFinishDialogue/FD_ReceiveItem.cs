using UnityEngine;

public class FD_ReceiveItem : MonoBehaviour, IFinishDialogue
{
    [SerializeField]
    private int itemID, itemQuantity;

    public void MakeAction()
    {
        InventoryManager.Instance.AddItem(itemID, itemQuantity);
    }
}
