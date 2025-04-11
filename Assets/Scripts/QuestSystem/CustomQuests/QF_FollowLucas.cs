using System.Collections.Generic;

using UnityEngine;

public class QF_FollowLucas : MonoBehaviour, IQuestFunctionality
{
    [Header("Quest Complete")]
    [SerializeField]
    private List<GameObject> objectToEnable = new List<GameObject>(5);

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
        for (int i = 0; i < objectToEnable.Count; i++)
        {
            objectToEnable[i].SetActive(true);
        }

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

        if (lucasRigidbody.isKinematic)
        {
            lucasRigidbody.isKinematic = false;
        }
        
        lucasTransform.localRotation = Quaternion.LookRotation(direction);
        lucasAnimatorControl.SetWalk(true);

        direction = direction.normalized * runSpeed;
        direction.y = -9.18f;
        lucasRigidbody.velocity = direction;
        return QuestState.IN_PROGRESS;
    }

    public void CompleteQuest()
    {
        for (int i = 0; i < objectToEnable.Count; i++) 
        {
            objectToEnable[i].SetActive(true);
        }
    }
}
