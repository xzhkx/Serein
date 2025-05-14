using UnityEngine;
using UnityEngine.VFX;

public class AttackVFXAnimationEvent : MonoBehaviour
{
    [SerializeField]
    private Transform VFXSplash;

    [SerializeField]
    private VisualEffect splash;

    private Vector3 combo01 = new Vector3(-38.152f, -118.921f, 593.672f);
    private Vector3 combo02 = new Vector3(0, 0, -12.75f);
    private Vector3 combo03 = new Vector3(-35.139f, 90, -90f);

    public void PlayVFX01()
    {
        VFXSplash.transform.position = transform.position;
        VFXSplash.eulerAngles = combo01;
        splash.Play();
    }

    public void PlayVFX02()
    {
        VFXSplash.transform.position = transform.position;
        VFXSplash.eulerAngles = combo02;
        splash.Play();
    }

    public void PlayVFX03() 
    {
        VFXSplash.transform.position = transform.position;
        VFXSplash.eulerAngles = combo03;
        splash.Play();
    }
}
