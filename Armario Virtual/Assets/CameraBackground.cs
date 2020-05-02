using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackground : MonoBehaviour
{

    Quaternion baseRotation;
    public static Renderer rendererBg;
    public static WebCamTexture _CamTex;
    public static Texture2D snap;
    int _CaptureCounter = 0;

     void Start () 
     {
        _CamTex = new WebCamTexture();
        _CamTex.requestedHeight = 512;
        _CamTex.requestedWidth = 512;
        baseRotation = transform.rotation;
        rendererBg = GetComponent<Renderer>();
        rendererBg.material.mainTexture = _CamTex;
        _CamTex.Play();
     }
    
    public void TakeSnapshot()
    {
        snap = new Texture2D(_CamTex.width, _CamTex.height);
        snap.SetPixels(_CamTex.GetPixels());
        snap.Apply();
        rendererBg.material.mainTexture = snap;
        
        // System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
        // ++_CaptureCounter;
    }

    void Update()
    {
        transform.rotation = baseRotation * Quaternion.AngleAxis(_CamTex.videoRotationAngle, Vector3.up);
    }
        
}
