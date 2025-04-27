using UnityEngine;

public class EnemyRandomMovement 
{
    private EnemyAnimatorControl animatorControl;

    private Transform currentTransform;
    private Rigidbody enemyRigidbody;

    private float activeRangeRadius;
    private float runSpeed;

    private Vector3 originalPosition, currentPosition;

    public EnemyRandomMovement(EnemyAnimatorControl animatorControl, 
        Transform currentTransform, Rigidbody enemyRigidbody,
        float activeRangeRadius, float runSpeed)
    {
        this.animatorControl = animatorControl;

        this.currentTransform = currentTransform;
        this.enemyRigidbody = enemyRigidbody;

        this.activeRangeRadius = activeRangeRadius;
        this.runSpeed = runSpeed;

        originalPosition = currentTransform.position;
        currentPosition = originalPosition;
    }

    public bool RandomMovement()
    {
        float distance = (currentTransform.position - currentPosition).sqrMagnitude;
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

    private Vector3 LookAtTarget(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - currentTransform.position;
        currentTransform.localRotation = Quaternion.LookRotation(direction);
        return direction.normalized;
    }
}
