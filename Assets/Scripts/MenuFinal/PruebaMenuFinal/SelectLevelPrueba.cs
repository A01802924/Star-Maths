using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SelectLevelPrueba : MonoBehaviour
{
    private Button playButton;
    private RadioButtonGroup worldButtonGroup;
    private RadioButtonGroup levelButtonGroup;
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        playButton = root.Q<Button>("PlayButton");
        worldButtonGroup = root.Q<RadioButtonGroup>("WorldRadioGroup");
        levelButtonGroup = root.Q<RadioButtonGroup>("LevelRadioGroup");
        playButton.RegisterCallback<ClickEvent>(PlayLevelGame);
        worldButtonGroup.RegisterValueChangedCallback(evt =>
        {
           SessionData.SelectedWorldID = evt.newValue + 1;
           print($"New world selection: {evt.newValue + 1}");
        });
        levelButtonGroup.RegisterValueChangedCallback(evt =>
        {
           SessionData.SelectedLevelID = evt.newValue + 1;
           print($"New level selection: {evt.newValue + 1}");
        });
    }
    public void PlayLevelGame(ClickEvent evt)
    {
        if (SessionData.SelectedWorldID > 0 && SessionData.SelectedLevelID > 0)
        {
            SceneManager.LoadScene("PlayLevelGamePrueba");
        }
    }
}
