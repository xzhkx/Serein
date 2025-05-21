using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class FadePresenter : MonoBehaviour
{
    public static FadePresenter Instance { get; private set; }
   
    [SerializeField]
    private UIDocument fadeUIDocument;

    private VisualElement fadePanel;

    private WaitForSeconds waitForSeconds1;
    private WaitForSeconds waitForSeconds0_5;

    private void Awake()
    {
        Instance = this;
        fadePanel = fadeUIDocument.rootVisualElement.Q<VisualElement>("FadePanel");
        fadePanel.visible = false;

        waitForSeconds1 = new WaitForSeconds(1);
        waitForSeconds0_5 = new WaitForSeconds(0.5f);
    }

    public void PlayFadeAnimation()
    {
        StartCoroutine(ReceiveFadeAnimation());
    }

    private IEnumerator ReceiveFadeAnimation()
    {
        fadePanel.visible = true;
        fadePanel.AddToClassList("fade-in");
        yield return waitForSeconds1;
        fadePanel.RemoveFromClassList("fade-in");
        yield return waitForSeconds0_5;
        fadePanel.visible = false;
    }
}
