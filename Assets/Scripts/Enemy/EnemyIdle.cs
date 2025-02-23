using UnityEngine;

public class EnemyIdle : MonoBehaviour
{ 
    [SerializeField] private float activeRangeRadius, runSpeed;
    [SerializeField] private float restTimer;
        
    private float timer;
    private Vector3 originalPosition, currentPosition;
    private Rigidbody enemyRigidbody;

    private void Awake()
    {
        timer = restTimer;
        originalPosition = transform.position;
        currentPosition = originalPosition;
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    public bool Rest()
    {
        if (timer <= 0) {
            timer = restTimer;
            return true;
        } else
        {
            timer -= Time.deltaTime;
            enemyRigidbody.velocity = Vector3.zero;
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
            currentPosition =  new Vector3(randomX, currentPosition.y, randomZ);
            return true;
        }
        else
        {
            Vector3 direction = (currentPosition - transform.position).normalized;
            enemyRigidbody.velocity = direction * runSpeed;
            transform.rotation = Quaternion.LookRotation(direction);
            return false;
        }
    }

    public void ResetPosition()
    {
        Vector3 direction = (transform.position - originalPosition).normalized;
        enemyRigidbody.velocity = direction * runSpeed;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
