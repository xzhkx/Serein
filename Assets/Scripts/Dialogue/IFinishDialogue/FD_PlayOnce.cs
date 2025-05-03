using UnityEngine;

public class FD_PlayOnce : MonoBehaviour, IFinishDialogue
{
    public void MakeAction()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
}
