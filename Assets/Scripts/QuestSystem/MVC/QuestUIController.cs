using UnityEngine;
using UnityEngine.UIElements;

public class QuestUIController : MonoBehaviour
{
    private QuestManager questManager;
    private QuestUIModel questUIModel;

    private void Awake()
    {
        questManager = GetComponent<QuestManager>();
        questUIModel = GetComponent<QuestUIModel>();
    }

    private void Start()
    {
        Button questInfoButton = questUIModel.GetQuestInfoButton();
        questInfoButton.RegisterCallback<ClickEvent>(OnSetQuestInfo);
    }


    private void OnSetQuestInfo(ClickEvent clickEvent)
    {
        
    }
}
