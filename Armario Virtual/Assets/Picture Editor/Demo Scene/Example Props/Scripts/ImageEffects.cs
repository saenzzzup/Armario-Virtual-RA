using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
public class ImageEffects : MonoBehaviour
{

    public static ImageEffects instance;
    public MeshRenderer testObject;
    public ImageEffect imageOne;
    public List<Texture2D> cutout = new List<Texture2D>();
    int typeOfImage;

    public GameObject removeButton;
    public GameObject takeButton;
    public GameObject saveButton;

    public void ChangeToImage()
    {
        if (SelectCutout.imageSelect <= 2 || SelectCutout.imageSelect == 4)
            typeOfImage = 0;
        else if (SelectCutout.imageSelect == 3)
            typeOfImage = 1;
        else 
            typeOfImage = 2;

        if ( CameraBackground.snap != null) {
            imageOne.sourceTex = CameraBackground.snap;
            imageOne.CustomCutout(cutout[SelectCutout.imageSelect]);
            removeButton.SetActive(true);
            saveButton.SetActive(true);
            takeButton.SetActive(false);
        }
        // testObject.transform.localScale = new Vector3((float)testObject.sharedMaterial.mainTexture.width / (float)testObject.sharedMaterial.mainTexture.height, 1, 1);

    }

    public void SaveToImage()
    {
        if(typeOfImage == 0)
            imageOne.saveFile(TopShotName(), testObject.sharedMaterial.mainTexture as Texture2D);
        else if (typeOfImage == 1)
            imageOne.saveFile(MiddleShotName(), testObject.sharedMaterial.mainTexture as Texture2D);
        else if (typeOfImage == 2)
            imageOne.saveFile(BottomShotName(), testObject.sharedMaterial.mainTexture as Texture2D);

        imageOne.sourceTex = null;
        removeButton.SetActive(false);
        saveButton.SetActive(false);
        takeButton.SetActive(true);
        CameraBackground.rendererBg.material.mainTexture = CameraBackground._CamTex;

    }

    public void CancelToImage()
    {
        imageOne.sourceTex = null;
        CameraBackground.snap = null;
        removeButton.SetActive(false);
        saveButton.SetActive(false);
        takeButton.SetActive(true);
        CameraBackground.rendererBg.material.mainTexture = CameraBackground._CamTex;

    }
    
    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            Instantiate(gameObject);
        }
    }

    public string BottomShotName() {
    return string.Format("clothe/Bottom/screen_{0}", 
        System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
    public string MiddleShotName() {
    return string.Format("clothe/Middle/screen_{0}", 
        System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
    public string TopShotName() {
    return string.Format("clothe/Top/screen_{0}", 
        System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
}
