using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BlurManager : MonoBehaviour
{
    public static BlurManager Instance;

    private Volume volume;
    private DepthOfField blur;

    private void Awake()
    {
        Instance = this;

        volume = GetComponent<Volume>();
        volume.profile.TryGet(out blur);

        DisableBlur();
    }

    public void EnableBlur()
    {
        blur.active = true;
    }

    public void DisableBlur() { 
        blur.active = false;
    }
}
