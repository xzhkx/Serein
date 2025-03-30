using UnityEngine;

public class LucasAnimatorControl : MonoBehaviour
{
    private Animator lucasAnimator;
    private Rigidbody lucasRigidbody;

    private void Awake()
    {
        lucasAnimator = GetComponent<Animator>();
        lucasRigidbody = GetComponent<Rigidbody>();
    }

    public void SetRun(bool boolean)
    {
        lucasAnimator.SetBool("isRun", boolean);
    }

    public void SetWalk(bool boolean)
    {
        lucasAnimator.SetBool("isWalk", boolean);
    }
}
