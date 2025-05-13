using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD_ReceiveItem : MonoBehaviour, ICompleteDeliver
{
    [SerializeField]
    private int itemID, itemQuantity;

    public void MakeAction()
    {
        InventoryManager.Instance.AddItem(itemID, itemQuantity);
    }
}
