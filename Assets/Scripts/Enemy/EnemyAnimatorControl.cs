using UnityEngine;

public class EnemyAnimatorControl : MonoBehaviour
{
    private Animator enemyAnimator;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    public void SetTrigger(string triggerName)
    {
        enemyAnimator.SetTrigger(triggerName);   
    }
}