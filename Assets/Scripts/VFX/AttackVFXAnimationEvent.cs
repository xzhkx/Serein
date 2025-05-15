using UnityEngine;
using UnityEngine.VFX;

public class AttackVFXAnimationEvent : MonoBehaviour
{
    [SerializeField]
    private Transform VFXSplash;

    [SerializeField]
    private VisualEffect splash;

    private Vector3 combo01 = new Vector3(0f, 0f, -45.4f);
    private Vector3 combo02 = new Vector3(0, 0, -12.75f);
    private Vector3 combo03 = new Vector3(-25f, 0, -90f);

    public void PlayVFX01()
    {
        VFXSplash.transform.localPosition = transform.localPosition;
        VFXSplash.eulerAngles = new Vector3(combo01.x, transform.eulerAngles.y, combo01.z);
        splash.Play();
    }

    public void PlayVFX02()
    {
        VFXSplash.transform.localPosition = transform.localPosition;
        VFXSplash.eulerAngles = new Vector3(combo02.x, transform.eulerAngles.y, combo02.z);
        splash.Play();
    }

    public void PlayVFX03() 
    {
        VFXSplash.transform.localPosition = transform.localPosition;
        VFXSplash.eulerAngles = new Vector3(combo03.x, transform.eulerAngles.y, combo03.z);
        splash.Play();
    }
}
