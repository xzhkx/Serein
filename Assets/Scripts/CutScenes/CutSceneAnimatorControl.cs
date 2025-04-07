using UnityEngine;

public class CutSceneAnimatorControl : MonoBehaviour
{
    [SerializeField] private Animator cameraControlAnimator;

    public void PlayAnimation(string name)
    {
        cameraControlAnimator.Play(name);
    }
}
