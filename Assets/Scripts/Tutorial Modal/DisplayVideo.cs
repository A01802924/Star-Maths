using UnityEngine;
using UnityEngine.UIElements;


public class DisplayVideo : MonoBehaviour
{
    private UIDocument document;
    private RenderTexture myRenderTexture;

    void Start()
    {
        document = GetComponent<UIDocument>();
        myRenderTexture = GetComponent<RenderTexture>();
        var visualElement = document.rootVisualElement.Q<VisualElement>("VideoContainer");
        visualElement.style.backgroundImage = Background.FromRenderTexture(myRenderTexture);
        visualElement.style.unityBackgroundImageTintColor = Color.white;
    }
}
