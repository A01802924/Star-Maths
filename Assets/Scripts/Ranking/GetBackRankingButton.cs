using System.Collections.Generic;
using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetBackRankingButton : MonoBehaviour
{
    private Button getBackButton;
    private Button web;
    private ScrollView rankingScrollView;

    private List<(int, string, int)> rankingTestValues = new()
    {
        (5, "Alexander", 1967),
        (1, "Cesar", 2026),
        (2, "Gian", 1989),
        (3, "Cass", 1975),
        (4, "Santi", 1971)
    };

    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();
        getBackButton = root.Q<Button>("GetBackButton");
        rankingScrollView = root.Q<ScrollView>("RankingContainer");
        getBackButton.clicked += GetBack;

        web = root.Q<Button>("WebButton");
        web.clicked += AbrirWeb;

        rankingScrollView.Q<Label>("NullRowsLabels").style.display = DisplayStyle.None;
        foreach ((int pos, string name, int score) user in rankingTestValues)
        {
            rankingScrollView.Add(RankingUIs.BuildRankingRow(user.pos, user.name, user.score));
        }
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
