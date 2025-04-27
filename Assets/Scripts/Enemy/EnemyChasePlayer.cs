using UnityEngine;

public class EnemyChasePlayer
{
    private Transform currentTransform;
    private Rigidbody enemyRigidbody;

    private Vector3 originalPosition;
    private float runSpeed;
    private float chaseSpeed;

    public EnemyChasePlayer(Transform currentTransform, Rigidbody enemyRigidbody, 
        float runSpeed, float chaseSpeed)
    {
        this.currentTransform = currentTransform;
        this.enemyRigidbody = enemyRigidbody;

        this.runSpeed = runSpeed;
        this.chaseSpeed = chaseSpeed;

        originalPosition = currentTransform.position;
    }

    public void ChasePlayer(Transform targetTransform)
    { 
        Vector3 direction = targetTransform.position - currentTransform.position;
        float distance = direction.sqrMagnitude;

        enemyRigidbody.velocity = direction.normalized * chaseSpeed;
        currentTransform.localRotation = Quaternion.LookRotation(direction);
    }
    public bool ResetPosition()
    {
        float distance = (currentTransform.position - originalPosition).sqrMagnitude;
        if (distance <= 0.02f)
        {
            Vector3 direction = (currentTransform.position - originalPosition).normalized;
            enemyRigidbody.velocity = direction * runSpeed;
            currentTransform.localRotation = Quaternion.LookRotation(direction);
            return false;
        }
        else return true;
    }
}
