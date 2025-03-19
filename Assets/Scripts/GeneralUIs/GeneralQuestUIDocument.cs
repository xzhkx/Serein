using UnityEngine;
using UnityEngine.UIElements;

public class GeneralQuestUIDocument : MonoBehaviour
{
    [SerializeField] private UIDocument generalUIDocument;
    [SerializeField] private UIDocument questUIDocument;

    private Button openQuestPanelButton;

    private void Start()
    {
        //visible
        openQuestPanelButton = generalUIDocument.rootVisualElement.Q<Button>("OpenQuestPanelButton");
        openQuestPanelButton.RegisterCallback<ClickEvent>(OnOpenQuestPanel);
    }

    private void OnOpenQuestPanel(ClickEvent clickEvent)
    {
        Debug.Log("Click");
    }
}
