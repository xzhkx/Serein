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

        if (distance < 0.05f && index < targetPosition.Length - 1)
        {
            index++;
            currentTarget = targetPosition[index].position;
            return QuestState.IN_PROGRESS;
        }

        if (distance < 0.05f && index == targetPosition.Length - 1)
        {
            lucasRigidbody.isKinematic = true;
            lucasAnimatorControl.SetWalk(false);
            return QuestState.COMPLETE;
        }

        lucasTransform.localRotation = Quaternion.LookRotation(direction);
        lucasAnimatorControl.SetWalk(true);
        lucasRigidbody.velocity = direction.normalized * runSpeed;
        return QuestState.IN_PROGRESS;
    }
}
