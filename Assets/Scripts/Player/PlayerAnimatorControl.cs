using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorControl : MonoBehaviour
{
    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        SetIdle(true);
        SetGrounded(true);
    }

    private Animator GetPlayerAnimator()
    {
        return playerAnimator;
    }
    
    public void SetIdle(bool boolean)
    {
        playerAnimator.SetBool("IsIdle", boolean);
    }

    public void SetGrounded(bool boolean) 
    {
        playerAnimator.SetBool("IsGrounded", boolean);
    }

    public void SetVelocityY(float velocity)
    {
        playerAnimator.SetFloat("VelocityY", velocity);
    }

    public void PlayAnimation(string animationName)
    {
        playerAnimator.Play(animationName);
    }
}
