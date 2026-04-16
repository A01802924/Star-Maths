using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetBackConfigButton : MonoBehaviour
{
    private Button homeButton;
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        homeButton = root.Q<Button>("CloseButton");
        homeButton.RegisterCallback<ClickEvent>(GoHome);
    }
    void GoHome(ClickEvent evt)
    {
        SceneManager.LoadScene("MenuPrincipalScene");
    }
}
