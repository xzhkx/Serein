using UnityEngine;

public class FD_UnlockFunctionality : MonoBehaviour, IFinishDialogue
{
    [SerializeField]
    private FunctionalityScriptableObject functionalityObject;
    [SerializeField]
    private GeneralPresenter generalPresenter;

    public void MakeAction()
    {
        UnlockFunctionalityPresenter.Instance.UnlockFunctionality(functionalityObject);
        generalPresenter.EnableFunctionalityButton(functionalityObject.ID);
    }
}
