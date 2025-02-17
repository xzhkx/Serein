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

    public void SetTriggerNextComboAttack()
    {
        playerAnimator.SetTrigger("NextCombo");
    }

    public bool CheckAnimationLength(float value)
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= value - 0.01f)
        {
            return true;
        }
        else return false;
    }
}
