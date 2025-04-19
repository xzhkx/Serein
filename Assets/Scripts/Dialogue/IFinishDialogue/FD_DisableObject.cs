using System.Collections;
using UnityEngine;

public class FD_DisableObject : MonoBehaviour, IFinishDialogue
{
    [SerializeField] private GameObject objectToDisable;
    public void MakeAction()
    {
        objectToDisable.SetActive(false);
    }
}
