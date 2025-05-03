using UnityEngine;

public class SubmitItemController : MonoBehaviour
{
    [SerializeField]
    private int itemToSubmit;

    [SerializeField]
    private Animator gateAnimator;

    public void SubmitSuccess()
    {
        itemToSubmit--;
        if(itemToSubmit == 0)
        {
            gateAnimator.enabled = true;
        }
    }
}
