using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetBackStoreButton : MonoBehaviour
{
    private Button getBackButton;
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();
        getBackButton = root.Q<Button>("CloseButton");
        getBackButton.clicked += GetBack;
    }

    private void GetBack()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickFormerWindow);
        SceneManager.LoadScene("Informacion");
    }
}
