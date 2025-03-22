using Ink.Parsed;
using System.Collections.Generic;
using UnityEngine;

public class QF_FollowLucas : MonoBehaviour, IQuestFunctionality
{
    [SerializeField] private float runSpeed;
    [SerializeField] private Transform targetPosition;

    private Rigidbody lucasRigidbody;

    private void Awake()
    {
        lucasRigidbody = GetComponent<Rigidbody>();
    }

    public QuestState StartQuestProgress()
    {
        Vector3 direction = targetPosition.position - transform.position;
        float distance = direction.sqrMagnitude;

        if(distance <= 0.02f)
        {
            lucasRigidbody.velocity = Vector3.zero;
            return QuestState.COMPLETE;
        }
        else
        {
            transform.localRotation = Quaternion.LookRotation(direction);
            lucasRigidbody.velocity = direction.normalized * runSpeed;
            return QuestState.IN_PROGRESS;
        }
    }
}
