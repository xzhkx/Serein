
using System.Numerics;
using UnityEngine;

public enum QuestState
{
    NON_EQUIP,
    EQUIP,
    IN_PROGRESS,
    COMPLETE
}

public class Quest 
{
    public string questName;
    public string questDescription;

    public Transform questTargetTransform;

    private QuestState questState;
    private IQuestFunctionality functionality;

    private QuestRequirements questRequirements;
    private QuestRewards questRewards;

    public Quest(string questName, string questDescription, Transform questTargetTransform, QuestState questState, 
        IQuestFunctionality functionality, QuestRequirements questRequirements, QuestRewards questRewards)
    {
        this.questName = questName;
        this.questDescription = questDescription;

        this.questTargetTransform = questTargetTransform;

        this.questState = questState;
        this.functionality = functionality;

        this.questRequirements = questRequirements;
        this.questRewards = questRewards;
    }

    public void SetQuestState(QuestState questState)
    {
        this.questState = questState;
    }

    public void StartQuest()
    {
        functionality.StartQuestProgress();
    }
}
