using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSRP : MonoBehaviour
{
    private void Awake()
    {
        MaterialPropertyBlock matBlock = new MaterialPropertyBlock();
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        renderer.SetPropertyBlock(matBlock);
    }
}
