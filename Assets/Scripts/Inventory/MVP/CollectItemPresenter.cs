using System;

using UnityEngine;
using UnityEngine.UIElements;

public class CollectItemPresenter : MonoBehaviour
{
    public static CollectItemPresenter Instance;
    public Action CollectItemAction;

    [SerializeField]
    private UIDocument generalUIDocument;

    private VisualElement collectItemPanel;
    private Button collectItemButton;

    private CollectItemModel collectItemModel;

    private void Awake()
    {
        Instance = this;

        collectItemButton = generalUIDocument.rootVisualElement.Q<Button>("CollectItemButton");
        collectItemPanel = generalUIDocument.rootVisualElement.Q<VisualElement>("CollectItemPanel");
    }

    private void Start()
    {
        collectItemModel = GetComponent<CollectItemModel>();
        collectItemButton.RegisterCallback<ClickEvent>(OnCollectItem);
    }

    public void CollectItem()
    {
        collectItemModel.CollectItem();
        DisableCollectButton();
        CollectItemAction?.Invoke();
    }

    public void OnCollectItem(ClickEvent clickEvent)
    {
        collectItemModel.CollectItem();
        DisableCollectButton();
        CollectItemAction?.Invoke();
    }

    public void SetCurrentItemID(int itemID)
    {
        collectItemModel.SetCurrentItemID(itemID);
    }

    public void DisplayCollectButton()
    {
        collectItemPanel.style.display = DisplayStyle.Flex;
    }

    public void DisableCollectButton()
    {
        collectItemPanel.style.display = DisplayStyle.None;
    }
}
