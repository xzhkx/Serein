using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [SerializeField]
    private GeneralPresenter generalPresenter;

    [SerializeField]
    private Transform playerTransform;

    private QuestPresenter questPresenter;
    public Quest currentQuest { get; private set; }
    private List<Quest> questList = new List<Quest>(10);

    private Camera mainCamera;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
        questPresenter = GetComponent<QuestPresenter>();
    }

    private void Update()
    {
        if (currentQuest == null) return;

        QuestState state = currentQuest.StartQuest();
        switch (state)
        {
            case QuestState.IN_PROGRESS:
                if (currentQuest.GetTargetPostion().Equals(Vector3.zero))
                {
                    break;
                }
                float distance = (playerTransform.position - currentQuest.GetTargetPostion()).magnitude;
                generalPresenter.SetTargetDistance(distance);
                break;

            case QuestState.COMPLETE:
                questList.Remove(currentQuest);
                questPresenter.RemoveQuest(currentQuest);
                generalPresenter.ClearGeneralQuest();

                currentQuest.CompleteQuest();   
                currentQuest = null;
                break;
        }
    }

    public bool QuestExists(Quest quest)
    {
        if(questList.Contains(quest)) return true; 
        else return false;
    }

    public void TrackQuest(Quest quest)
    {
        currentQuest = quest;
        quest.SetQuestState(QuestState.IN_PROGRESS);
        generalPresenter.SetGeneralQuestName(quest.GetQuestName());
    }

    public void ReceiveQuest(Quest quest)
    {
        if (currentQuest == null) {
            currentQuest = quest;
            generalPresenter.SetGeneralQuestName(quest.GetQuestName());
        }
        questList.Add(quest);
        questPresenter.CreateNewQuest(quest);
    }

    public void StartQuest()
    {
        currentQuest.StartQuest();
    }

    public Quest GetCurrentQuest()
    {
        return currentQuest;
    }
}
