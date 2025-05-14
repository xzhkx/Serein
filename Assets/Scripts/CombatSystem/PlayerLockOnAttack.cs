using UnityEngine;

public class PlayerLockOnAttack : MonoBehaviour
{
    [SerializeField] 
    private LayerMask enemyLayerMask;

    [SerializeField] 
    private float detectEnemyRadius;

    [SerializeField]
    private int damage;

    private GameObject currentEnemyLockOn;
    private Collider[] enemiesInRange;

    private void Awake()
    {
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
        Vector3 direction = currentEnemyLockOn.transform.position - transform.position;
        direction.y = 0;
        transform.localRotation = Quaternion.LookRotation(direction);
        currentEnemyLockOn.GetComponent<IDamagable>().TakeDamage(damage);
    }
}
