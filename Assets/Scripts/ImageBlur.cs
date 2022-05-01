using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageBlur : MonoBehaviour
{

    public Material mat;

    RenderTexture rt;

    void Start()
    {
        rt = new RenderTexture(Screen.width, Screen.height, 1);
        mat.SetTexture("_MainTex", rt);
    }


    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        rt = src;
        mat.SetTexture("_MainTex", rt);
        Graphics.Blit(src, dest, mat);
    }
}
