using System.Collections.Generic;
using UnityEngine;

public class SD_DisableObject : MonoBehaviour, IStartDialogue
{
    [SerializeField] 
    private List<GameObject> objectToDisable;
    public void MakeAction()
    {
        for(int i = 0; i < objectToDisable.Count; i++)
        {
            objectToDisable[i].SetActive(false);
        }
    }
}
