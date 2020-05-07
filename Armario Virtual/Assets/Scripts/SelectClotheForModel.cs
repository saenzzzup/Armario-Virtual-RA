using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeClothe {Top, Middle, Bottom};

public class SelectClotheForModel : MonoBehaviour
{
    public TypeClothe typeClothe;
    // Start is called before the first frame update
    public void SelectImage(int selector){
        Image thisImage = transform.gameObject.GetComponent<Image>();

        if (TypeClothe.Top == typeClothe)
            ClotheSelector.topClothe = thisImage.sprite.texture;
        else if (TypeClothe.Middle == typeClothe)
            ClotheSelector.middleClothe = thisImage.sprite.texture;
        else if (TypeClothe.Bottom == typeClothe)
            ClotheSelector.bottomClothe = thisImage.sprite.texture;
    }
}
