
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
    private QuestState questState;
    private IQuestFunctionality functionality;
    private QuestRequirements questRequirements;
    private QuestRewards questRewards;

    public Quest(string questName, string questDescription, QuestState questState, 
        IQuestFunctionality functionality, QuestRequirements questRequirements, QuestRewards questRewards)
    {
        this.questName = questName;
        this.questDescription = questDescription;
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
