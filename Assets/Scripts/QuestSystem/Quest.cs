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

    public Quest(QuestScriptableObject questScriptableObject, 
        QuestRewardScriptableObject questRewardScriptableObject, IQuestFunctionality functionality)
    {
        questState = QuestState.IN_PROGRESS;
        this.questScriptableObject = questScriptableObject;
        this.questRewardScriptableObject = questRewardScriptableObject; 
        this.functionality = functionality;
    }

    public string GetQuestName()
    {
        return questScriptableObject.questName;
    }

    public string GetQuestIconName()
    {
        return questScriptableObject.questIconName;
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
