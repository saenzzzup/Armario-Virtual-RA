using UnityEngine;

public class SceneFade : MonoBehaviour
{
    public float time;
    public Color loadToColor = Color.black;
    // Start is called before the first frame update

    void Start(){
        Screen.fullScreen = false;
    }

    public void FadeToScreen(string scene){
        Initiate.Fade(scene,loadToColor,time);
        if ( CameraBackground._CamTex != null && CameraBackground._CamTex.isPlaying)
            CameraBackground._CamTex.Stop();
            CameraBackground.snap = null;
    }
}
