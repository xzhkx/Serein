using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] private Transform targetTransform;
    private Rigidbody enemyRigidbody;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    public void ChasePlayer()
    {
        Vector3 direction = targetTransform.position - transform.position;
        float distance = direction.sqrMagnitude;

        enemyRigidbody.velocity = direction.normalized * runSpeed;
        transform.localRotation = Quaternion.LookRotation(direction);
    }
}
