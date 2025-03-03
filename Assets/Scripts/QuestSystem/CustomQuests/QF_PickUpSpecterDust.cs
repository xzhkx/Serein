using UnityEngine;

public class QF_PickUpSpecterDust : MonoBehaviour, IQuestFunctionality
{
    private bool pickedUp;

    private void Awake()
    {
        pickedUp = false;
    }
    public QuestState StartQuestProgress()
    {
        if (pickedUp)
        {
            return QuestState.COMPLETE;
        } else return QuestState.IN_PROGRESS;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            pickedUp = true;
        }
    }
}
