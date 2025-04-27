using UnityEngine;

public class EnemyIdle
{
    private EnemyAnimatorControl animatorControl;

    private Transform currentTransform;
    private Rigidbody enemyRigidbody;

    private float restTimer;
    private float normalTimer;

    public EnemyIdle(EnemyAnimatorControl animatorControl, Transform currentTransform, 
        Rigidbody enemyRigidbody, float restTimer)
    {
        this.animatorControl = animatorControl;
        this.currentTransform = currentTransform;

        this.enemyRigidbody = enemyRigidbody;
        this.restTimer = restTimer;

        normalTimer = restTimer;
    }

    public bool Rest()
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
}
