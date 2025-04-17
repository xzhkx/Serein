using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class FadePresenter : MonoBehaviour
{
    public static FadePresenter Instance { get; private set; }
   
    [SerializeField]
    private UIDocument fadeUIDocument;

    private VisualElement fadePanel;

    private void Awake()
    {
        Instance = this;
        fadePanel = fadeUIDocument.rootVisualElement.Q<VisualElement>("FadePanel");
        fadePanel.visible = false;
    }

    public void PlayFadeAnimation()
    {
        StartCoroutine(ReceiveFadeAnimation());
    }

    private IEnumerator ReceiveFadeAnimation()
    {
        fadePanel.visible = true;
        fadePanel.AddToClassList("fade-in");
        yield return new WaitForSeconds(1f);
        fadePanel.RemoveFromClassList("fade-in");
        yield return new WaitForSeconds(0.5f);
        fadePanel.visible = false;
    }
}
