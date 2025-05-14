using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterStatsPresenter : MonoBehaviour
{
    [SerializeField] 
    private UIDocument generalUIDocument;

    [SerializeField]
    private UIDocument characterStatsUIDocument;

    [SerializeField]
    private Camera statsCamera;

    private VisualElement statsPanel;
    private Button openStatsButton;

    private void Awake()
    {
        statsPanel = characterStatsUIDocument.rootVisualElement
            .Q<VisualElement>("CharacterStatsPanel");
        statsPanel.visible = false;

        openStatsButton = generalUIDocument.rootVisualElement.Q<Button>("OpenStatsButton");
        openStatsButton.RegisterCallback<ClickEvent>(OpenCharacterStatsPanel);
    }


    private void OpenCharacterStatsPanel(ClickEvent clickEvent)
    {
        StartCoroutine(ReceiveFadeAnimation());
    }

    private IEnumerator ReceiveFadeAnimation()
    {
        FadePresenter.Instance.PlayFadeAnimation();
        yield return new WaitForSeconds(1f);
        statsCamera.enabled = true;
        statsPanel.visible = true;
        statsPanel.style.display = DisplayStyle.Flex;
    }
}

