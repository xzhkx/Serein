using UnityEngine;

public class InGameQuest : MonoBehaviour
{
    [Header("Quest Info")]
    [SerializeField]
    private QuestScriptableObject questScriptableObject;

    [SerializeField]
    private Transform targetTransform;

    [Header("Quest Reward")]
    [SerializeField]
    private QuestRewardScriptableObject questRewardScriptableObject;

    private Quest thisQuest;
    private IQuestFunctionality functionality;

    private void Awake()
    {
        functionality = GetComponent<IQuestFunctionality>();
        thisQuest = new Quest(questScriptableObject, questRewardScriptableObject, 
            functionality, targetTransform);
    }

    public void ReceiveQuest()
    {
        if (QuestManager.Instance.QuestExists(thisQuest)) return;
        QuestManager.Instance.ReceiveQuest(thisQuest);
    }
}
