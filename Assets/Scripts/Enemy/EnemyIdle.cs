using UnityEngine;

public class EnemyIdle : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float activeRangeRadius, runSpeed;
    [SerializeField] private float restTimer, restAfterAttackTimer;
        
    private float normalTimer, restAttackTimer;
    private Vector3 originalPosition, currentPosition;
    private Rigidbody enemyRigidbody;

    private void Awake()
    {
        normalTimer = restTimer;
        restAttackTimer = restAfterAttackTimer;

        originalPosition = transform.position;
        currentPosition = originalPosition;
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    public bool NormalRest()
    {
        if (normalTimer <= 0) {
            normalTimer = restTimer;
            return true;
        } else
        {
            normalTimer -= Time.deltaTime;
            enemyRigidbody.velocity = Vector3.zero;
            return false;
        }
    }

    public bool RestAfterAttack()
    {
        if (restAttackTimer <= 0)
        {
            restAttackTimer = restAfterAttackTimer;
            return true;
        }
        else
        {
            restAttackTimer -= Time.deltaTime;
            LookAtTarget(playerTransform.position);
            enemyRigidbody.velocity = Vector3.back * 2f;
            return false;
        }
    }

    public bool RandomMovement()
    {
        float distance = (transform.position - currentPosition).sqrMagnitude;
        if (distance <= 0.2f)
        {
            float randomX = Random.Range(originalPosition.x - activeRangeRadius, originalPosition.x + activeRangeRadius);
            float randomZ = Random.Range(originalPosition.z - activeRangeRadius, originalPosition.z + activeRangeRadius);
            currentPosition = new Vector3(randomX, currentPosition.y, randomZ);
            return true;
        }
        else
        {
            enemyRigidbody.velocity = LookAtTarget(currentPosition) * runSpeed;
            return false;
        }
    }

    public bool ResetPosition()
    {
        float distance = (transform.position - originalPosition).sqrMagnitude;
        if (distance <= 0.02f)
        {
            Vector3 direction = (transform.position - originalPosition).normalized;
            enemyRigidbody.velocity = direction * runSpeed;
            transform.localRotation = Quaternion.LookRotation(direction);
            return false;
        }
        else return true;
    }

    private Vector3 LookAtTarget(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        transform.localRotation = Quaternion.LookRotation(direction);
        return direction.normalized;
    }
}
