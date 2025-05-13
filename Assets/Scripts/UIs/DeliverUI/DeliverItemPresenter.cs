using System;
using UnityEngine;
using UnityEngine.UIElements;

public class DeliverItemPresenter : MonoBehaviour
{
    [SerializeField]
    private UIDocument deliverUIDocument;

    private QF_DeliverItemTrack QFdeliverItem;

    private VisualElement deliverPanel, itemIcon;
    private Button deliverButton, closePanelButton;

    public Action<int> DeliverCompleteEvent;
    public Action<int, int, Texture2D> SetCurrentItemEvent;
    private int currentItemID, currentQuantity;

    private void Awake()
    {
        deliverButton = deliverUIDocument.rootVisualElement.Q<Button>("DeliverButton");
        deliverButton.RegisterCallback<ClickEvent>(DeliverItem);

        closePanelButton = deliverUIDocument.rootVisualElement.Q<Button>("ClosePanelButton");
        closePanelButton.RegisterCallback<ClickEvent>(CloseDeliverPanel);

        itemIcon = deliverUIDocument.rootVisualElement.Q<VisualElement>("ItemIcon");

        deliverPanel = deliverUIDocument.rootVisualElement.Q<VisualElement>("DeliverPanel");
        deliverPanel.visible = false;

        SetCurrentItemEvent += SetCurrentItem;
    }

    public void OnDisable()
    {
        SetCurrentItemEvent -= SetCurrentItem;
    }

    public void SetQFDeliveryTrack(QF_DeliverItemTrack deliverItemTrack)
    {
        QFdeliverItem = deliverItemTrack;
    }

    public void DeliverItem(ClickEvent clickEvent)
    {
        if(InventoryManager.Instance.RemoveItem(currentItemID, currentQuantity))
        {
            deliverPanel.visible = false;
            if (QFdeliverItem != null) {
                QFdeliverItem.DeliverSuccess(currentItemID);
            }
            DeliverCompleteEvent?.Invoke(currentItemID);
        } else
        {
            Debug.Log("Cant find item to deliver");
        }
    }

    private void CloseDeliverPanel(ClickEvent clickEvent)
    {
        deliverPanel.visible = false;
    }

    public void EnableDeliverPanel()
    {
        deliverPanel.visible = true;
    }

    public void SetCurrentItem(int itemID, int quantity, Texture2D itemIcon) { 
        currentItemID = itemID;
        currentQuantity = quantity;
        this.itemIcon.style.backgroundImage = itemIcon;
    }
}
