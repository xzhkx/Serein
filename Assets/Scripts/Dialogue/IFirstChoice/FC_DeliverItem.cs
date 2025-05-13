using UnityEngine;

public class FC_DeliverItem : MonoBehaviour, IFirstChoice
{
    [SerializeField]
    private int itemID, quantity;

    [SerializeField]
    private Texture2D itemIcon;

    [SerializeField]
    private DeliverItemPresenter deliverPresenter;

    [SerializeField]
    private QF_DeliverItemTrack deliverItemTrack;

    private ICompleteDeliver iCompleteDeliver;

    private void Awake()
    {
        iCompleteDeliver = GetComponent<ICompleteDeliver>();
    }

    private void OnEnable()
    {
        deliverPresenter.DeliverCompleteEvent += DeliverComplete;
    }

    private void OnDisable()
    {
        deliverPresenter.DeliverCompleteEvent -= DeliverComplete;
    }

    private void DeliverComplete(int itemID)
    {
        if (itemID != this.itemID) return;
        gameObject.SetActive(false);
        if(iCompleteDeliver != null)
        {
            iCompleteDeliver.MakeAction();
        }
    }

    public void MakeAction()
    {
        deliverPresenter.EnableDeliverPanel();
    }

    private void OnTriggerEnter(Collider collider)
    {
        deliverPresenter.SetQFDeliveryTrack(deliverItemTrack);
        deliverPresenter.SetCurrentItem(itemID, quantity, itemIcon);
    }
}
