using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MycoAnimatorControl : MonoBehaviour
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
