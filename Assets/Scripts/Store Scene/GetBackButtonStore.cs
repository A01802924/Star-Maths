using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetBackButtonStore : MonoBehaviour
{
    private Button getBackButton;
    private VisualElement goToCustomizationButton;
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        getBackButton = root.Q<Button>("GetBackButton");
        getBackButton.RegisterCallback<ClickEvent>(GetBack);
        goToCustomizationButton = root.Q<VisualElement>("BackpackButton");
        goToCustomizationButton.RegisterCallback<ClickEvent>(GoToCustomizationScene);
    }
    void GetBack(ClickEvent evt)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickFormerWindow);
        SceneManager.LoadScene("Informacion");
    }
    private void GoToCustomizationScene(ClickEvent evt)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
        SceneManager.LoadScene("Customize");
    }
}
