using UnityEngine;

public class CutSceneAnimatorControl : MonoBehaviour
{
    [SerializeField] private Animator cameraControlAnimator;

    public void EnableCamera()
    {
        cameraControlAnimator.enabled = true;
    }

    public void DisableCamera()
    {
        cameraControlAnimator.enabled = false;
    }

    public void PlayAnimation(string name)
    {
        cameraControlAnimator.Play(name);
    }
}
