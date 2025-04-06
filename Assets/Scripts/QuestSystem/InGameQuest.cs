using UnityEngine;

public class InGameQuest : MonoBehaviour
{
    [Header("Quest Info")]
    [SerializeField]
    private QuestScriptableObject questScriptableObject;

    [Header("Quest Reward")]
    [SerializeField]
    private QuestRewardScriptableObject questRewardScriptableObject;

    private Quest thisQuest;
    private IQuestFunctionality functionality;
    private void Awake()
    {
        functionality = GetComponent<IQuestFunctionality>();
        thisQuest = new Quest(questScriptableObject, questRewardScriptableObject, functionality);
    }

    public void ReceiveQuest()
    {
        QuestManager.Instance.ReceiveQuest(thisQuest);
    }
}
