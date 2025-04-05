using UnityEngine;

public class QF_PickUpSpecterDust : MonoBehaviour, IQuestFunctionality
{
    [SerializeField]
    private GameObject objectToDisable, d2, objectToEnable;

    private InventoryManager inventoryManager;

    private void Start()
    {
        objectToDisable.SetActive(false);
        objectToEnable.SetActive(false);
        inventoryManager = InventoryManager.Instance;
    }

    public QuestState StartQuestProgress()
    {
        if (!objectToDisable.activeInHierarchy)
        {
            objectToDisable.SetActive(true);
        }
        if (inventoryManager.GetItemQuantity(0) > 0)
        {
            return QuestState.COMPLETE;
        }
        else return QuestState.IN_PROGRESS;
    }

    public void CompleteQuest()
    {
        objectToDisable.SetActive(false);
        objectToEnable.SetActive(true);
        d2.SetActive(false);
    }
}
