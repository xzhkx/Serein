using System;
using UnityEngine;
using UnityEngine.UIElements;

public class DeliverItemPresenter : MonoBehaviour
{
    [SerializeField]
    private UIDocument deliverUIDocument;

    private VisualElement deliverPanel;
    private Button deliverButton;

    public static Action<int> SetCurrentItemEvent;
    private int currentItemID;

    private void Awake()
    {
        deliverPanel = deliverUIDocument.rootVisualElement.Q<VisualElement>("DeliverPanel");
        deliverButton = deliverUIDocument.rootVisualElement.Q<Button>("DeliverButton");

        deliverPanel.visible = false;
        deliverButton.RegisterCallback<ClickEvent>(DeliverItem);

        SetCurrentItemEvent += SetCurrentItem;
    }

    public void OnDisable()
    {
        SetCurrentItemEvent -= SetCurrentItem;
    }

    public void DeliverItem(ClickEvent clickEvent)
    {
        if(InventoryManager.Instance.RemoveItem(currentItemID, 1))
        {
            deliverPanel.visible = false;
        } else
        {
            Debug.Log("Cant find item to deliver");
        }
    }

    public void EnableDeliverPanel()
    {
        deliverPanel.visible = true;
    }

    public void SetCurrentItem(int itemID) { 
        currentItemID = itemID; 
    }
}
