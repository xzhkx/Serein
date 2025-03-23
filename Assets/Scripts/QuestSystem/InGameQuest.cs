using UnityEngine;

public class InGameQuest : MonoBehaviour
{
    [Header("Quest Info")]
    [SerializeField] private string questName, questDescription;

    [Header("Quest Requirements")]
    [SerializeField] private int characterLevel;

    [Header("Quest Rewards")]
    [SerializeField] private int specterDust;

    private Quest thisQuest;
    private IQuestFunctionality functionality;
    private void Awake()
    {
        QuestRequirements questRequirements = new QuestRequirements(characterLevel);
        QuestRewards questRewards = new QuestRewards(characterLevel);
        functionality = GetComponent<IQuestFunctionality>();
        thisQuest = new Quest(questName, questDescription, QuestState.NON_EQUIP, functionality, questRequirements, questRewards);
    }

    public void ReceiveQuest()
    {
        QuestManager.Instance.ReceiveQuest(thisQuest);
    }
}
