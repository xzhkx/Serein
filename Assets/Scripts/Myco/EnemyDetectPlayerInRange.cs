using UnityEngine;

public class EnemyDetectPlayerInRange : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private float sightRangeRadius, attackRangeRadius;

    public bool IsPlayerInSightRange()
    {
        if (Physics.CheckSphere(transform.position, sightRangeRadius, playerLayerMask))
        {
            return true;
        } 
        else return false;
    }

    public bool IsPlayerInAttackRange() 
    {
        if (Physics.CheckSphere(transform.position, attackRangeRadius, playerLayerMask))
        {
            return true;
        }
        else return false;
    }
}
