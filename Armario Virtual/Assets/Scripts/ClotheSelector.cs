using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClotheSelector : MonoBehaviour
{
    public static Texture2D topClothe;
    public static Texture2D middleClothe;
    public static Texture2D bottomClothe;

    public List<Texture2D> clothesFirstTextues = new List<Texture2D>();
    public List<Image> clothes = new List<Image>();

    void Start() {
        topClothe = clothesFirstTextues[0];
        middleClothe = clothesFirstTextues[1];
        bottomClothe = clothesFirstTextues[2];
    }

    void Update() {
        clothes[0].sprite = Sprite.Create (topClothe, new Rect (0, 0, topClothe.width, topClothe.height), new Vector2 (0.5f,0.5f));
        clothes[1].sprite = Sprite.Create (middleClothe, new Rect (0, 0, middleClothe.width, middleClothe.height), new Vector2 (0.5f,0.5f));
        clothes[2].sprite = Sprite.Create (bottomClothe, new Rect (0, 0, bottomClothe.width, bottomClothe.height), new Vector2 (0.5f,0.5f));
        clothes[3].sprite = Sprite.Create (bottomClothe, new Rect (0, 0, bottomClothe.width, bottomClothe.height), new Vector2 (0.5f,0.5f));
    }

}
