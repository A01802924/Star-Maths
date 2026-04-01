using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetBackStoreButton : MonoBehaviour
{
    private Button getBackButton;
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        getBackButton = root.Q<Button>("CloseButton");
        getBackButton.RegisterCallback<ClickEvent>(GetBack);
    }

    void GetBack(ClickEvent evt)
    {
        SceneManager.LoadScene("Informacion");
    }
}
