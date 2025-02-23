using UnityEngine;

public class EnemyAnimatorControl : MonoBehaviour
{
    private Animator mycoAnimator;

    private void Awake()
    {
        mycoAnimator = GetComponent<Animator>();
    }

    public void SetTrigger(string triggerName)
    {
        mycoAnimator.SetTrigger(triggerName);   
    }
}