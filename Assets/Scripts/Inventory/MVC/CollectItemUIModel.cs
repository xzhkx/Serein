using UnityEngine.UIElements;
using UnityEngine;

public class CollectItemUIModel : MonoBehaviour
{
    [SerializeField]
    private UIDocument generalUIDocument;

    private CollectItemUIController collectItemUIController;
    private Button collectItemButton;

    private void Awake()
    {
        collectItemButton = generalUIDocument.rootVisualElement.Q<Button>("CollectItemButton");
        collectItemButton.style.display = DisplayStyle.None;
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
        collectItemButton.style.display = DisplayStyle.Flex;
    }

    public void DisableCollectItemButton()
    {
        collectItemButton.style.display = DisplayStyle.None;
    }
}
