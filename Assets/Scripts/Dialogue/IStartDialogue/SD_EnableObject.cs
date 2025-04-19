using System.Collections.Generic;
using UnityEngine;

public class SD_EnableObject : MonoBehaviour, IStartDialogue
{
    [SerializeField]
    private List<GameObject> objectToEnable = new List<GameObject>(5);

    [SerializeField]
    private List<Transform> targetTransform = new List<Transform>(5);

    public void MakeAction()
    {
        for (int i = 0; i < targetTransform.Count; i++) {
            if (targetTransform[i] != null)
            {
                objectToEnable[i].transform.position = targetTransform[i].position;
                objectToEnable[i].transform.localRotation = targetTransform[i].localRotation;
            }
        }
        for (int i = 0; i < objectToEnable.Count; i++)
        {
            if(objectToEnable[i] != null)
            {
                objectToEnable[i].SetActive(true);
            }
        }
    }
}
