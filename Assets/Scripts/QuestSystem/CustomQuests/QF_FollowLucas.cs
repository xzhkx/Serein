using UnityEngine;

public class QF_FollowLucas : MonoBehaviour, IQuestFunctionality
{
    [SerializeField] private float runSpeed;
    [SerializeField] private Transform[] targetPositions;

    private Rigidbody lucasRigidbody;

    private Vector3 nextPosition;
    private int index = 0;

    private void Awake()
    {
        lucasRigidbody = GetComponent<Rigidbody>();
        nextPosition = targetPositions[index].position;
    }

    public QuestState StartQuestProgress()
    {
        Vector3 direction = nextPosition - transform.position;
        float distance = direction.sqrMagnitude;

        if(index == targetPositions.Length - 1 && distance <= 0.02f)
        {
            return QuestState.COMPLETE;
        }
        if (distance <= 0.02f)
        {
            index++;
            nextPosition = targetPositions[index].position;
            return QuestState.IN_PROGRESS;
        }
        else
        {
            transform.localRotation = Quaternion.LookRotation(direction);
            lucasRigidbody.velocity = direction.normalized * runSpeed;
            return QuestState.IN_PROGRESS;
        }
    }
}
