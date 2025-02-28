using UnityEngine;

public class PlayerLockOnAttack : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private float detectEnemyRadius;

    private AttackVFX attackVFX;

    private GameObject currentEnemyLockOn;
    private Collider[] enemiesInRange;

    private void Awake()
    {
        attackVFX = GetComponent<AttackVFX>();
        enemiesInRange = new Collider[5];
    }

    private void Update()
    {
        CheckAttackRange();
    }

    private void CheckAttackRange()
    {
        if (Physics.CheckSphere(transform.position, detectEnemyRadius, enemyLayerMask))
        {
            int numberColliders = Physics.OverlapSphereNonAlloc(transform.localPosition, detectEnemyRadius,
                enemiesInRange, enemyLayerMask);
            currentEnemyLockOn = enemiesInRange[0].gameObject;
        }
        else
        {
            currentEnemyLockOn = null;
        }
    }

    public void LookAtTarget()
    {
        if (currentEnemyLockOn == null) return;
        Vector3 direction = currentEnemyLockOn.transform.localPosition - transform.localPosition;
        transform.localRotation = Quaternion.LookRotation(direction);

        attackVFX.PlayAttackVFX(currentEnemyLockOn.transform.position);
        currentEnemyLockOn.GetComponent<EnemyTakeDamage>().TakeDamage(2);
    }
}
