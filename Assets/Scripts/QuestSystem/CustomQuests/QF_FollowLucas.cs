using UnityEngine;

public class QF_FollowLucas : MonoBehaviour, IQuestFunctionality
{
    [SerializeField] 
    private float runSpeed;

    [SerializeField] 
    private Transform[] targetPosition;

    [SerializeField]
    private Rigidbody lucasRigidbody;

    [SerializeField]
    private LucasAnimatorControl lucasAnimatorControl;

    private Transform lucasTransform;
    private Vector3 currentTarget;
    private int index;

    private void Awake()
    {
        lucasTransform = lucasRigidbody.transform;
        index = 0;
        currentTarget = targetPosition[index].position;
    }

    public QuestState StartQuestProgress()
    {
        Vector3 direction = currentTarget - lucasTransform.position;
        float distance = direction.sqrMagnitude;

        if(distance < 0.03f && index < targetPosition.Length - 1)
        {
            index++;
            lucasRigidbody.velocity = Vector3.zero;
            currentTarget = targetPosition[index].position;
            return QuestState.IN_PROGRESS;
        }

        if(distance < 0.03f && index == targetPosition.Length - 1)
        {
            lucasAnimatorControl.SetWalk(false);
            lucasRigidbody.velocity = Vector3.zero;
            return QuestState.COMPLETE;
        }

        lucasTransform.localRotation = Quaternion.LookRotation(direction);
        lucasAnimatorControl.SetWalk(true);
        lucasRigidbody.velocity = direction.normalized * runSpeed;
        return QuestState.IN_PROGRESS;
    }
}
