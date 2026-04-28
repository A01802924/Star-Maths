using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    private const string videoFileName = "TutorialVideoTemplate.mp4";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualElement videoContainer = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("VideoContainer");
        RenderTexture rTex = Resources.Load<RenderTexture>("");
    }
}
