using System.Collections;
using UnityEngine;

public class TriggerDisappear : MonoBehaviour
{
    [SerializeField]
    private string objectTag;

    [SerializeField]
    private TextAsset inkScript;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(objectTag))
        {
            StartCoroutine(ReceiveDisappear(collider.gameObject));
        }
    }

    private IEnumerator ReceiveDisappear(GameObject gameObject)
    {      
        FadePresenter.Instance.PlayFadeAnimation();
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        if (inkScript != null) DialogueManager.Instance.EnterDialogue(inkScript);
    }
}
