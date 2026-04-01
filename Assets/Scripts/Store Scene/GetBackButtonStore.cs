using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetBackButtonStore : MonoBehaviour
{
    private Button getBackButton;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        getBackButton = root.Q<Button>("GetBackButton");
        getBackButton.RegisterCallback<ClickEvent>(GetBack);
    }
    
    void GetBack(ClickEvent evt)
    {
        SceneManager.LoadScene("Informacion");
    }
}
