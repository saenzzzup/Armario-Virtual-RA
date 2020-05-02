using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class clotheLoader : MonoBehaviour
{
    public GameObject imageHolder;
    public Image imageUI;
    // Start is called before the first frame update
    void Start()
    {
        DirectoryInfo di = new DirectoryInfo(Application.dataPath + "/clothe/Top");
        DirCount(di);
    }

    public void SelectClothe(int selectNumber) {
        foreach (Transform child in imageHolder.transform) {
            GameObject.Destroy(child.gameObject);
        }

        DirectoryInfo di;
        if ( selectNumber == 0)
            di = new DirectoryInfo(Application.dataPath + "/clothe/Top");
        else if ( selectNumber == 1)
            di = new DirectoryInfo(Application.dataPath + "/clothe/Middle");
        else
            di = new DirectoryInfo(Application.dataPath + "/clothe/Bottom");
        
        DirCount(di);
    }

    public void DirCount(DirectoryInfo d){
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis)
        {
            if (fi.Extension.Contains("png")) {
                byte[] byteArray = File.ReadAllBytes(fi.FullName);
                Texture2D sampleTexture = new Texture2D(512,512);
                bool isLoaded = sampleTexture.LoadImage(byteArray);
		        if (isLoaded) {
                    var newImage = Instantiate (imageUI, imageHolder.transform);
                    var sprite = Sprite.Create (sampleTexture, new Rect (0, 0, sampleTexture.width, sampleTexture.height), new Vector2 (0.5f,0.5f));
                    newImage.sprite = sprite;
                }
            }
        }
    }

}
