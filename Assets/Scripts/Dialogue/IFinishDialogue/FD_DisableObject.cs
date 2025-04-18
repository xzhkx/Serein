using System.Collections;
using UnityEngine;

public class FD_DisableObject : MonoBehaviour, IFinishDialogue
{
    [SerializeField] private GameObject objectToDisable;
    public void MakeAction()
    {
        StartCoroutine(DisappearObject());
    }

    private IEnumerator DisappearObject()
    {
        FadePresenter.Instance.PlayFadeAnimation();
        yield return new WaitForSeconds(0.5f);
        objectToDisable.SetActive(false);
    }
}
