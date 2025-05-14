using UnityEngine;

public class EnemyLockOnAttack : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayerMask;

    [SerializeField]
    private float detectEnemyRadius;

    [SerializeField]
    private int damage;

    private GameObject currentPlayerLockOn;
    private Collider[] playersInRange = new Collider[10];


    public void DealDamage()
    {
        if (Physics.CheckSphere(transform.position, detectEnemyRadius, playerLayerMask))
        {
            int numberColliders = Physics.OverlapSphereNonAlloc(transform.position, detectEnemyRadius,
                playersInRange, playerLayerMask);
            currentPlayerLockOn = playersInRange[0].gameObject;

            Debug.Log("dmg");
            currentPlayerLockOn.GetComponent<IDamagable>().TakeDamage(damage);
        }
    }
}
