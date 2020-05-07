using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowFullImage : MonoBehaviour
{
    public string imageUrl;
    public void OpenModal() {
        GameObject modalImageObj = GameObject.FindWithTag("Modal Image");
        Image modalImage = modalImageObj.GetComponent<Image>();
        Image thisImage = transform.gameObject.GetComponent<Image>();
        modalImage.sprite = thisImage.sprite;

        Lean.Gui.LeanButton buttonCtrl = GameObject.FindWithTag("delete button").GetComponent<Lean.Gui.LeanButton>();
        buttonCtrl.OnClick.AddListener(() => DeleteImage());
    }

    public void DeleteImage() {
        if ( File.Exists( imageUrl ) ) {
            File.Delete( imageUrl );
            transform.gameObject.SetActive(false);
        }
    }
}
