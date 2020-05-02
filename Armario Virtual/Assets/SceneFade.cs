using UnityEngine;

public class SceneFade : MonoBehaviour
{
    public float time;
    public Color loadToColor = Color.black;
    // Start is called before the first frame update
    public void FadeToScreen(string scene){
        Initiate.Fade(scene,loadToColor,time);
        if (CameraBackground._CamTex.isPlaying)
            CameraBackground._CamTex.Stop();
            CameraBackground.snap = null;
    }
}
