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

    [SerializeField]
    private YYriPlayerStats playerStats;

    private VisualElement statsPanel;
    private Button openStatsButton, closeStatsButton;

    private TextElement soulLevelStat, hpStat, attackStat, defStat;

    private void Awake()
    {
        statsPanel = characterStatsUIDocument.rootVisualElement
            .Q<VisualElement>("CharacterStatsPanel");
        statsPanel.visible = false;

        openStatsButton = generalUIDocument.rootVisualElement.Q<Button>("OpenStatsButton");
        openStatsButton.RegisterCallback<ClickEvent>(OpenCharacterStatsPanel);

        closeStatsButton = characterStatsUIDocument.rootVisualElement.Q<Button>("ClosePanelButton");
        closeStatsButton.RegisterCallback<ClickEvent>(CloseCharacterStatsPanel);

        soulLevelStat = characterStatsUIDocument.rootVisualElement.Q<TextElement>("SoulLevelStat");
        hpStat = characterStatsUIDocument.rootVisualElement.Q<TextElement>("HPStat");
        attackStat = characterStatsUIDocument.rootVisualElement.Q<TextElement>("AttackStat");
        defStat = characterStatsUIDocument.rootVisualElement.Q<TextElement>("DEFStat");
    }

    private void OnEnable()
    {
        playerStats.StatsChangeAction += UpdateStats;
    }

    private void OnDisable()
    {
        playerStats.StatsChangeAction -= UpdateStats;
    }


    private void UpdateStats(CharacterStatsScriptableIObject stats)
    {
        soulLevelStat.text = stats.soulLevel.ToString();
        hpStat.text = stats.hp.ToString();
        attackStat.text = stats.attack.ToString();
        defStat.text = stats.defense.ToString();
    }

    private void OpenCharacterStatsPanel(ClickEvent clickEvent)
    {
        StartCoroutine(OpenStats());
    }

    private IEnumerator OpenStats()
    {
        FadePresenter.Instance.PlayFadeAnimation();
        yield return new WaitForSeconds(1f);
        statsCamera.enabled = true;
        statsPanel.visible = true;
        statsPanel.style.display = DisplayStyle.Flex;
    }

    private void CloseCharacterStatsPanel(ClickEvent clickEvent)
    {
        StartCoroutine(CloseStats());
    }

    private IEnumerator CloseStats()
    {
        FadePresenter.Instance.PlayFadeAnimation();
        yield return new WaitForSeconds(1f);
        statsCamera.enabled = false;
        statsPanel.visible = false;
        statsPanel.style.display = DisplayStyle.None;
    }
}

