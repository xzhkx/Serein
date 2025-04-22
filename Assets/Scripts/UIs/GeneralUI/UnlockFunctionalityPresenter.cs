using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class UnlockFunctionalityPresenter : MonoBehaviour
{
    public static UnlockFunctionalityPresenter Instance;

    [SerializeField]
    private UIDocument unlockUIDocument;

    private VisualElement functionalityPanel, functionalityIcon;
    private TextElement functionalityName, functionalityDescription;

    private void Awake()
    {
        Instance = this;

        functionalityPanel = unlockUIDocument.rootVisualElement.Q<VisualElement>("FunctionalityPanel");
        functionalityIcon = unlockUIDocument.rootVisualElement.Q<VisualElement>("FunctionalityIcon");

        functionalityName = unlockUIDocument.rootVisualElement.Q<TextElement>("FunctionalityName");
        functionalityDescription = unlockUIDocument.rootVisualElement.Q<TextElement>("FunctionalityDescription");

        functionalityPanel.visible = false;
    }

    public void UnlockFunctionality(FunctionalityScriptableObject functionality)
    {
        StartCoroutine(ReceiveFunctionalityAnimation(functionality));
    }

    private IEnumerator ReceiveFunctionalityAnimation(FunctionalityScriptableObject functionality)
    {
        functionalityPanel.visible = true;
        functionalityIcon.style.backgroundImage = functionality.functionalityIcon;
        functionalityName.text = functionality.functionalityName;
        functionalityDescription.text = functionality.functionalityDescription;

        yield return new WaitForSeconds(1f);
        functionalityPanel.AddToClassList("fade-in");
        yield return new WaitForSeconds(5f);
        functionalityPanel.RemoveFromClassList("fade-in");
        yield return new WaitForSeconds(1f);
        functionalityPanel.visible = false;
    }
}
