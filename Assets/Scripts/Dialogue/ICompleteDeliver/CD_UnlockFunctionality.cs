using UnityEngine;

public class CD_UnlockFunctionality : MonoBehaviour, ICompleteDeliver
{
    [SerializeField]
    private FunctionalityScriptableObject functionalityObject;
    [SerializeField]
    private GeneralPresenter generalPresenter;
    [SerializeField]
    private FreezePlayerControl freezePlayerControl;

    public void MakeAction()
    {
        UnlockFunctionalityPresenter.Instance.UnlockFunctionality(functionalityObject);
        generalPresenter.EnableFunctionalityButton(functionalityObject.ID);
        freezePlayerControl.UnlockAttack();
    }
}
