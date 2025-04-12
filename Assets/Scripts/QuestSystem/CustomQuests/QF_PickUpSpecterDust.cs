using System.Collections.Generic;
using UnityEngine;

public class QF_PickUpSpecterDust : MonoBehaviour, IQuestFunctionality
{
    [SerializeField]
    private GameObject specterDust;

    [Header("Quest Complete")]
    [SerializeField]
    private List<GameObject> objectToEnable, objectToDisable = new List<GameObject>(5);

    private InventoryManager inventoryManager;

    private void Start()
    {
        specterDust.SetActive(false);
        inventoryManager = InventoryManager.Instance;
    }

    public QuestState StartQuestProgress()
    {
        if(!specterDust.activeInHierarchy)
        {
            specterDust.SetActive(true);
        }
        if (inventoryManager.GetItemQuantity(0) > 0)
        {
            return QuestState.COMPLETE;
        }
        else return QuestState.IN_PROGRESS;
    }

    public void CompleteQuest()
    {
        ModifyObjects();
    }

    private void ModifyObjects()
    {
        for (int i = 0; i < objectToDisable.Count; i++)
        {
            objectToDisable[i].SetActive(false);
        }
        for (int i = 0; i < objectToEnable.Count; i++)
        {
            objectToEnable[i].SetActive(true);
        }
    }
}
