using UnityEngine;

public class DetectItem : MonoBehaviour
{
    [SerializeField]
    private int itemID;

    private CollectItemPresenter collectItemPresenter;
    private PlayerInput playerInput;

    private bool playerInRange = false;

    private void Start()
    {
        playerInput = PlayerInput.Instance;
        collectItemPresenter = CollectItemPresenter.Instance;
    }

    private void Update()
    {
        if (playerInRange) {
            if (playerInput.GetInteractPressed())
            {
                collectItemPresenter.CollectItem();
            }
        }
    }

    private void OnCollectItem()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Player")) return;

        playerInRange = true;

        collectItemPresenter.CollectItemAction += OnCollectItem;
        collectItemPresenter.DisplayCollectButton();
        collectItemPresenter.SetCurrentItemID(itemID);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Player")) return;

        playerInRange = false;

        collectItemPresenter.CollectItemAction -= OnCollectItem;
        collectItemPresenter.DisableCollectButton();
    }
}
