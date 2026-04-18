using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetBackRankingButton : MonoBehaviour
{
    private Button getBackButton;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(ConfigurationPreferences.DarkScreenLayer);
        getBackButton = root.Q<Button>("GetBackButton");
        getBackButton.clicked += GetBack;
    }

    private void GetBack()
    {
        SceneManager.LoadScene("Informacion");
    }
}
