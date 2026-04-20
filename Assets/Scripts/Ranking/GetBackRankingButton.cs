using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetBackRankingButton : MonoBehaviour
{
    private Button getBackButton;
    private Button web;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();
        getBackButton = root.Q<Button>("GetBackButton");
        getBackButton.clicked += GetBack;

        web = root.Q<Button>("WebButton");
        web.clicked += AbrirWeb;
    }

    private void GetBack()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickFormerWindow);
        SceneManager.LoadScene("Informacion");
    }

    private void AbrirWeb()
    {
        Application.OpenURL("http://star-maths.s3-website-us-east-1.amazonaws.com/ranking.html");
    }
}
