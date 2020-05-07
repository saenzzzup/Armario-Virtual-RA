using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTextures : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    // Start is called before the first frame update
    void Start()
    {
        materials[0].mainTexture = ClotheSelector.topClothe;
        materials[1].mainTexture = ClotheSelector.middleClothe;
        materials[2].mainTexture = ClotheSelector.bottomClothe;
    }

}
