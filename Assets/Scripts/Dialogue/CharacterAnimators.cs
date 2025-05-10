using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimators : MonoBehaviour
{
    [SerializeField]
    private List<Animator> characterAnimators = new List<Animator>(3);

    public Animator GetCurrentAnimator(int animatorID)
    {
        return characterAnimators[animatorID];
    }
}
