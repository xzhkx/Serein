using UnityEngine;

public enum QuestState
{
    IN_PROGRESS,
    COMPLETE
}

public class Quest 
{
    public QuestScriptableObject questScriptableObject;
    private QuestRewardScriptableObject questRewardScriptableObject;

    private QuestState questState;
    private IQuestFunctionality functionality;

    private Transform targetTransform;

    public Quest(QuestScriptableObject questScriptableObject,
        QuestRewardScriptableObject questRewardScriptableObject, IQuestFunctionality functionality,
        Transform targetTransform)
    {
        questState = QuestState.IN_PROGRESS;
        this.questScriptableObject = questScriptableObject;
        this.questRewardScriptableObject = questRewardScriptableObject; 
        this.functionality = functionality;
        this.targetTransform = targetTransform;
    }

    public string GetQuestName()
    {
        return questScriptableObject.questName;
    }

    public string GetQuestIconName()
    {
        return questScriptableObject.questIconName;
    }

    public Vector3 GetTargetPostion()
    {
        if(targetTransform == null) return Vector3.zero;
        return targetTransform.position;
    }

    public Texture2D GetQuestIcon()
    {
        return questScriptableObject.questIcon;
    }

    public string GetQuestDescription()
    {
        return questScriptableObject.questDescription;
    }

    public void SetQuestState(QuestState questState)
    {
        this.questState = questState;
    }

    public QuestState StartQuest()
    {
        return functionality.StartQuestProgress();
    }

    public void CompleteQuest()
    {
        functionality.CompleteQuest();
    }
}
