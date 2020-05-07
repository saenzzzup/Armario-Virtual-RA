using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class clotheLoader : MonoBehaviour
{
    public GameObject imageHolder;
    public GameObject modal;
    public Image imageUI;
    public TypeClothe typeClothe;
    // Start is called before the first frame update
    void Start()
    {
        var directoryPath1 = Application.persistentDataPath + "/clothe/Top";
        var directoryPath2 = Application.persistentDataPath + "/clothe/Middle";
        var directoryPath3 = Application.persistentDataPath + "/clothe/Bottom";
        Directory.CreateDirectory(directoryPath1);
        Directory.CreateDirectory(directoryPath2);
        Directory.CreateDirectory(directoryPath3);

        DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath + "/clothe/Top");
        DirCount(di, TypeClothe.Top);
    }

    public void SelectClothe(int selectNumber) {
        foreach (Transform child in imageHolder.transform) {
            GameObject.Destroy(child.gameObject);
        }

        DirectoryInfo di;
        if ( selectNumber == 0) {
            di = new DirectoryInfo(Application.persistentDataPath + "/clothe/Top");
            typeClothe = TypeClothe.Top;
        } else if ( selectNumber == 1) {
            di = new DirectoryInfo(Application.persistentDataPath + "/clothe/Middle");
            typeClothe = TypeClothe.Middle;
        } else {
            di = new DirectoryInfo(Application.persistentDataPath + "/clothe/Bottom");
            typeClothe = TypeClothe.Bottom;
        }
        
        DirCount(di, typeClothe);
    }

    public void DirCount(DirectoryInfo d, TypeClothe typeClothe){
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

                    SelectClotheForModel selectClotheModal = newImage.GetComponent(typeof(SelectClotheForModel)) as SelectClotheForModel;
                    if (selectClotheModal != null) {
                        selectClotheModal.typeClothe = typeClothe;
                        Lean.Gui.LeanButton buttonCtrl = newImage.GetComponent<Lean.Gui.LeanButton>();
                        buttonCtrl.OnClick.AddListener(() => modal.GetComponent<Lean.Gui.LeanWindow>().TurnOff());
                    } else {
                        Lean.Gui.LeanButton buttonCtrl = newImage.GetComponent<Lean.Gui.LeanButton>();
                        buttonCtrl.OnClick.AddListener(() => modal.GetComponent<Lean.Gui.LeanWindow>().TurnOn());
                        newImage.GetComponent<ShowFullImage>().imageUrl = fi.FullName;

                    }
                }
            }
        }
    }

}
