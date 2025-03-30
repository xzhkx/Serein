using UnityEngine;

public class ReceiveQuestCollider : MonoBehaviour
{
    [SerializeField]
    private InGameQuest inGameQuest;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inGameQuest.ReceiveQuest();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
