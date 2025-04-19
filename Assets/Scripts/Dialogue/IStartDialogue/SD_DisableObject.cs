using UnityEngine;

public class SD_DisableObject : MonoBehaviour, IStartDialogue
{
    [SerializeField] private GameObject objectToDisable;
    public void MakeAction()
    {
        objectToDisable.SetActive(false);
    }
}
