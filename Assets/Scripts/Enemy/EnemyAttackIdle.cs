using UnityEngine;

public class EnemyAttackIdle 
{
    private Transform currentTransform;
    private Rigidbody enemyRigidbody;

    private EnemyAnimatorControl enemyAnimatorControl;

    private float restAfterAttackTimer;
    private float restAttackTimer;

    public EnemyAttackIdle(EnemyAnimatorControl enemyAnimatorControl, Transform currentTransform, 
        Rigidbody enemyRigidbody, float restAfterAttackTimer)
    {
        this.currentTransform = currentTransform;
        this.enemyRigidbody = enemyRigidbody;

        this.enemyAnimatorControl = enemyAnimatorControl;
        this.restAfterAttackTimer = restAfterAttackTimer;

        restAttackTimer = restAfterAttackTimer;
    }

    public bool RestAfterAttack(Transform targetTransform)
    {
        if (restAttackTimer <= 0)
        {
            restAttackTimer = restAfterAttackTimer;
            return true;
        }
        else
        {
            restAttackTimer -= Time.deltaTime;
            LookAtTarget(targetTransform.position);
            enemyRigidbody.velocity = Vector3.back * 2f;
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
