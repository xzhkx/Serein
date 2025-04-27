using UnityEngine;

public class EnemyDetectPlayerInRange
{
    private Transform currentTransform;
    private LayerMask playerLayerMask;

    private float sightRangeRadius;
    private float attackRangeRadius;

    public EnemyDetectPlayerInRange(Transform currentTransform, 
        LayerMask playerLayerMask, float sightRangeRadius, float attackRangeRadius)
    {
        this.currentTransform = currentTransform;
        this.playerLayerMask = playerLayerMask;

        this.sightRangeRadius = sightRangeRadius;
        this.attackRangeRadius = attackRangeRadius;
    }

    public bool IsPlayerInSightRange()
    {
        if (Physics.CheckSphere(currentTransform.position, sightRangeRadius, playerLayerMask))
        {
            return true;
        } 
        else {
            return false;
        }
    }

    public bool IsPlayerInAttackRange() 
    {
        if (Physics.CheckSphere(currentTransform.position, attackRangeRadius, playerLayerMask))
        {
            return true;
        }
        else return false;
    }
}
