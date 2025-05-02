using UnityEngine;
using UnityEngine.UIElements;

public class CharacterStatsPresenter : MonoBehaviour
{
    [SerializeField]
    private UIDocument characterStatsUIDocument;

    private VisualElement characterStatsPanel;

    private void Awake()
    {
        characterStatsPanel = characterStatsUIDocument.rootVisualElement
            .Q<VisualElement>("CharacterStatsPanel");
        characterStatsPanel.visible = false;
    }
}
