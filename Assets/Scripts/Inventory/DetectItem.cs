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

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;
        collectItemUIController.DisplayCollectItemButton();
        collectItemUIController.currentItemID = itemID;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;
        collectItemUIController.DisplayCollectItemButton();
    }
}
