using UnityEngine;

public class SF_UnlockFunctionality : MonoBehaviour, IFinishDialogue
{
    [SerializeField]
    private FunctionalityScriptableObject functionalityObject;
    [SerializeField]
    private GeneralPresenter generalPresenter;

    public void MakeAction()
    {
        UnlockFunctionalityPresenter.Instance.UnlockFunctionality(functionalityObject);
        generalPresenter.EnableInventoryButton();
    }
}
