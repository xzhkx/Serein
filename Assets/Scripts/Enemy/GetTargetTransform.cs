using UnityEngine;

public class GetTargetTransform : MonoBehaviour
{
    private Transform targetTransform;
    private EnemyAnimatorControl enemyAnimatorControl;

    private void Awake()
    {
        enemyAnimatorControl = GetComponent<EnemyAnimatorControl>();
    }

    public Transform GetTarget()
    {
        return targetTransform;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            targetTransform = collider.transform;
            enemyAnimatorControl.SetTrigger("SnapTrigger");
        } 
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            targetTransform = null;
            enemyAnimatorControl.SetTrigger("IdleTrigger");
        }
    }
}
