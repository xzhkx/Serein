using UnityEngine;

public class FC_SubmitItem : MonoBehaviour, IFirstChoice
{
    [SerializeField]
    private int itemID, itemQuantity;
    public void MakeAction()
    {
        if(InventoryManager.Instance.RemoveItem(itemID, itemQuantity))
        {
            GetComponent<SubmitItemController>().SubmitSuccess();
            this.enabled = false;
        }
    }
}
