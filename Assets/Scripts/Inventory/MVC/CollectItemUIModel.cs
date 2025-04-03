using UnityEngine.UIElements;
using UnityEngine;

public class CollectItemUIModel : MonoBehaviour
{
    [SerializeField]
    private UIDocument generalUIDocument;

    private CollectItemUIController collectItemUIController;
    private VisualElement collectItemPanel;
    private Button collectItemButton;

    private void Awake()
    {
        collectItemButton = generalUIDocument.rootVisualElement.Q<Button>("CollectItemButton");
        collectItemPanel = generalUIDocument.rootVisualElement.Q<VisualElement>("CollectItemPanel");
        collectItemPanel.style.display = DisplayStyle.None;
    }

    private void Start()
    {
        collectItemUIController = CollectItemUIController.Instance;
    }

    public Button GetCollectItemButton()
    {
        return collectItemButton;
    }

    public void DisplayCollectItemButton()
    {
        collectItemPanel.style.display = DisplayStyle.Flex;
    }

    public void DisableCollectItemButton()
    {
        collectItemPanel.style.display = DisplayStyle.None;
    }
}
