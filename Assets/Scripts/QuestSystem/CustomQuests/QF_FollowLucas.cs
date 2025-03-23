using UnityEngine;

public class QF_FollowLucas : MonoBehaviour, IQuestFunctionality
{
    [SerializeField] private float runSpeed;
    [SerializeField] private Transform[] targetPosition;

    private Rigidbody lucasRigidbody;
    private Vector3 currentTarget;
    private int index;

    private void Awake()
    {
        lucasRigidbody = GetComponent<Rigidbody>();
        index = 0;
        currentTarget = targetPosition[index].position;
    }

    public QuestState StartQuestProgress()
    {
        Vector3 direction = currentTarget - transform.position;
        float distance = direction.sqrMagnitude;

        if(distance < 0.02f && index < targetPosition.Length - 1)
        {
            index++;
            currentTarget = targetPosition[index].position;
            return QuestState.IN_PROGRESS;
        }

        if(distance < 0.02f && index == targetPosition.Length - 1)
        {
            lucasRigidbody.velocity = Vector3.zero;
            return QuestState.COMPLETE;
        }

        transform.localRotation = Quaternion.LookRotation(direction);
        lucasRigidbody.velocity = direction.normalized * runSpeed;
        return QuestState.IN_PROGRESS;
    }
}
