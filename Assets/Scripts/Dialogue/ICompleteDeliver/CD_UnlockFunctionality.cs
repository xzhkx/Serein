using UnityEngine;

public class CD_UnlockFunctionality : MonoBehaviour, ICompleteDeliver
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
