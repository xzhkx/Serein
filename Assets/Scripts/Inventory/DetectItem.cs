using UnityEngine;

public class DetectItem : MonoBehaviour
{
    [SerializeField]
    private int itemID;

    private CollectItemUIController collectItemUIController;

    private void Start()
    {
        collectItemUIController = CollectItemUIController.Instance;
    }

    private void OnCollectItem()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;

        collectItemUIController.CollectItemAction += OnCollectItem;
        collectItemUIController.DisplayCollectItemButton();
        collectItemUIController.currentItemID = itemID;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;

        collectItemUIController.CollectItemAction -= OnCollectItem;
        collectItemUIController.DisableCollectItemButton();
    }
}
