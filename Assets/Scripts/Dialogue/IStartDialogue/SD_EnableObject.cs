using UnityEngine;

public class SD_EnableObject : MonoBehaviour, IStartDialogue
{
    [SerializeField]
    private GameObject objectToEnable;

    [SerializeField]
    private Transform targetTransform;

    public void MakeAction()
    {
        if (targetTransform != null) {
            objectToEnable.transform.position = targetTransform.position;
        }
        objectToEnable.SetActive(true);
    }
}
