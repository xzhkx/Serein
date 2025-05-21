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

    private WaitForSeconds waitForSeconds1;
    private WaitForSeconds waitForSeconds5;

    private void Awake()
    {
        Instance = this;

        functionalityPanel = unlockUIDocument.rootVisualElement.Q<VisualElement>("FunctionalityPanel");
        functionalityIcon = unlockUIDocument.rootVisualElement.Q<VisualElement>("FunctionalityIcon");

        functionalityName = unlockUIDocument.rootVisualElement.Q<TextElement>("FunctionalityName");
        functionalityDescription = unlockUIDocument.rootVisualElement.Q<TextElement>("FunctionalityDescription");

        functionalityPanel.visible = false;

        waitForSeconds1 = new WaitForSeconds(1);
        waitForSeconds5 = new WaitForSeconds(5);
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

        yield return waitForSeconds1;
        functionalityPanel.AddToClassList("fade-in");
        yield return waitForSeconds5;
        functionalityPanel.RemoveFromClassList("fade-in");
        yield return waitForSeconds1;
        functionalityPanel.visible = false;
    }
}
