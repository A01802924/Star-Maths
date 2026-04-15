using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetBackFromCustomization : MonoBehaviour
{
    private Button getBackButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        getBackButton = root.Q<Button>("GetBackButton");
        getBackButton.RegisterCallback<ClickEvent>(GetBack);
    }

    private void GetBack(ClickEvent evt)
    {
        SceneManager.LoadScene("Store");
    }
}
