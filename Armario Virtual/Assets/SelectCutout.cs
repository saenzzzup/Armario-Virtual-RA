using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCutout : MonoBehaviour
{
    Renderer renderer;
    public List<Texture2D> cutout = new List<Texture2D>();
    public static int imageSelect;

     void Start () 
     {
        imageSelect = 0;
        renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = cutout[0];
     }

    public void SetCutImage(int imageSelectInput){
        imageSelect = imageSelectInput;
        renderer.material.mainTexture = cutout[imageSelect];
    }
}
