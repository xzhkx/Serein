using UnityEngine;

public class DetectItem : MonoBehaviour
{
    [SerializeField]
    private int itemID;

    private CollectItemPresenter collectItemPresenter;

    private void Start()
    {
        collectItemPresenter = CollectItemPresenter.Instance;
    }

    private void OnCollectItem()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        collectItemPresenter.CollectItemAction += OnCollectItem;
        collectItemPresenter.DisplayCollectButton();
        collectItemPresenter.SetCurrentItemID(itemID);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        collectItemPresenter.CollectItemAction -= OnCollectItem;
        collectItemPresenter.DisableCollectButton();
    }
}
