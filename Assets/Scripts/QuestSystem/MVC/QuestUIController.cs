using UnityEngine;
using UnityEngine.UIElements;

public class QuestUIController : MonoBehaviour
{
    private QuestManager questManager;
    private QuestUIView questUIView;

    private void Awake()
    {
        questManager = GetComponent<QuestManager>();
        questUIView = GetComponent<QuestUIView>();
    }

    private void Start()
    {
        Button openQuestInfoButton = questUIView.GetOpenQuestInfoButton();
        //openQuestInfoButton.RegisterCallback<ClickEvent>(SetQuestInfo);
    }

}
