using UnityEngine;

public class QF_PickUpSpecterDust : MonoBehaviour, IQuestFunctionality
{
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = InventoryManager.Instance;
    }

    public QuestState StartQuestProgress()
    {
        if (inventoryManager.GetItemQuantity(0) > 1)
        {
            return QuestState.COMPLETE;
        }
        else return QuestState.IN_PROGRESS;
    }
}
