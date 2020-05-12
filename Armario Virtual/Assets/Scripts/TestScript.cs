using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject gameObjectToInstansiate;
    private GameObject gameObInsta;
    // Start is called before the first frame update
    void Start()
    {
        gameObInsta = Instantiate(gameObjectToInstansiate, new Vector3(0,0,0), Quaternion.identity);
        gameObInsta.transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
        
    }
}
