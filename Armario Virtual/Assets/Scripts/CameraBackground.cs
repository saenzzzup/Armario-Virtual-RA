using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackground : MonoBehaviour
{

    Quaternion baseRotation;
    public static Renderer rendererBg;
    public static WebCamTexture _CamTex;
    public static Texture2D snap;

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
        snap = RotateImage(snap);
        snap.Apply();
        rendererBg.material.mainTexture = snap;
    }

    void Update()
    {
        if ( snap == null)
            transform.rotation = baseRotation * Quaternion.AngleAxis(_CamTex.videoRotationAngle, Vector3.up);
        else
            transform.rotation = baseRotation;

    }

    public Texture2D RotateImage(Texture2D originTexture){
        Texture2D result;
        result = new Texture2D(originTexture.width, originTexture.height);
        Color32[] pix1 = result.GetPixels32();
        Color32[] pix2 = originTexture.GetPixels32();
        int W = originTexture.width;
        int H = originTexture.height;
        int x = 0;
        int y = 0;
        // transform.eulerAngles.y
        Color32[] pix3 = rotateSquare(pix2, (Mathf.PI/-180*(float)_CamTex.videoRotationAngle), originTexture);
        for (int j = 0; j < H; j++){
             for (var i = 0; i < W; i++) {
                 //pix1[result.width/2 - originTexture.width/2 + x + i + result.width*(result.height/2-originTexture.height/2+j+y)] = pix2[i + j*originTexture.width];
                 pix1[result.width/2 - W/2 + x + i + result.width*(result.height/2-H/2+j+y)] = pix3[i + j*W];
             }
         }
        result.SetPixels32(pix1);
        result.Apply();
        return result;
     }

    Color32[] rotateSquare(Color32[] arr, float phi, Texture2D originTexture){
         int x;
         int y;
         int i;
         int j;
         double sn = Mathf.Sin(phi);
         double cs = Mathf.Cos(phi);
         Color32[] arr2 = originTexture.GetPixels32();
         int W = originTexture.width;
         int H = originTexture.height;
         int xc = W/2;
         int yc = H/2;
         for (j=0; j<H; j++){
             for (i=0; i<W; i++){
                 arr2[j*W+i] = new Color32(0,0,0,0);
                 x = (int)(cs*(i-xc)+sn*(j-yc)+xc);
                 y = (int)(-sn*(i-xc)+cs*(j-yc)+yc);
                 if ((x>-1) && (x<W) &&(y>-1) && (y<H)){ 
                     arr2[j*W+i]=arr[y*W+x];
                 }
             }
         }
         return arr2;
     }
  
}
