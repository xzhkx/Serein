using UnityEngine;

public class FC_DeliverItem : MonoBehaviour, IFirstChoice
{
    [SerializeField]
    private int itemID, quantity;

    [SerializeField]
    private DeliverItemPresenter deliverPresenter;

    public void MakeAction()
    {
        deliverPresenter.EnableDeliverPanel();
    }

    private void OnTriggerEnter(Collider collider)
    {
        deliverPresenter.SetCurrentItem(itemID);
    }
}
