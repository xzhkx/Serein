using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MycoChasePlayer : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] private Transform targetTransform;
    private Rigidbody mycoRigidbody;


    private void Awake()
    {
        mycoRigidbody = GetComponent<Rigidbody>();
    }

    public void ChasePlayer()
    {
        Vector3 direction = targetTransform.position - transform.position;
        float distance = direction.sqrMagnitude;

        mycoRigidbody.velocity = direction.normalized * runSpeed;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
