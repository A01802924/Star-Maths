using System.Collections.Generic;
using Assets.Scripts.Core;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Configurations : MonoBehaviour
{
    private Slider brightnessSlider;
    private Slider musicSlider;
    private Slider SFXSlider;
    private Label brightnessPercentageLabel;
    private Label musicPercentageLabel;
    private Label SFXPercentageLabel;
    private Button saveChangesButton;
    private Button resetConfigurationButton;
    private VisualElement confirmExitContainer;
    private Button confirmExitConfigurationButton;
    private Button discardExitConfigurationButton;
    private VisualElement exitConfigurationCrossButton;
    private Button homeButton;
    private VisualElement root;
    private float tempBrightnessValue;
    private float tempMusicValue;
    private float tempSFXValue;
    private bool existUnsavedChanges = false;
    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        root.Add(ConfigurationPreferences.DarkScreenLayer);

        tempBrightnessValue = ConfigurationPreferences.ScreenBrightness;
        tempMusicValue = ConfigurationPreferences.MusicVolume;
        tempSFXValue = ConfigurationPreferences.SFXVolume;

        brightnessSlider = root.Q<Slider>("BrightnessSlider");
        musicSlider = root.Q<Slider>("MusicSlider");
        SFXSlider = root.Q<Slider>("SFXSlider");
        brightnessPercentageLabel = root.Q<Label>("BrightnessSliderIndexLabel");
        musicPercentageLabel = root.Q<Label>("MusicSliderIndexLabel");
        SFXPercentageLabel = root.Q<Label>("SFXSliderIndexLabel");
        saveChangesButton = root.Q<Button>("SaveChangesButton");
        resetConfigurationButton = root.Q<Button>("RestoreDefault");
        confirmExitContainer = root.Q<VisualElement>("ConfirmExitPopUpContainer");
        exitConfigurationCrossButton = root.Q<VisualElement>("PopUpCrossButtonContainer");
        confirmExitConfigurationButton = root.Q<Button>("ConfirmButton");
        discardExitConfigurationButton = root.Q<Button>("DiscardButton");
        homeButton = root.Q<Button>("CloseButton");

        brightnessSlider.value = tempBrightnessValue;
        brightnessPercentageLabel.text = tempBrightnessValue.ToString() + "%";
        musicSlider.value = tempMusicValue;
        musicPercentageLabel.text = tempMusicValue.ToString() + "%";
        SFXSlider.value = tempSFXValue;
        SFXPercentageLabel.text = tempSFXValue.ToString() + "%";

        brightnessSlider.RegisterValueChangedCallback(evt => SetNewBrightness(evt));
        musicSlider.RegisterValueChangedCallback(evt => SetNewMusicVolume(evt));
        SFXSlider.RegisterValueChangedCallback(evt => SetNewSFXVolume(evt));
        exitConfigurationCrossButton.RegisterCallback<ClickEvent>(evt => HidePopUpDialog());
        homeButton.RegisterCallback<ClickEvent>(evt => TryGoingHome());
        saveChangesButton.clicked += SaveNewConfigurationPreferences;
        resetConfigurationButton.clicked += ResetConfigurations;
        confirmExitConfigurationButton.clicked += GoHomeWithNoChanges;
        discardExitConfigurationButton.clicked += HidePopUpDialog;
    }
    private void TryGoingHome()
    {
        if (existUnsavedChanges)
        {
            confirmExitContainer.style.display = DisplayStyle.Flex;
        }
        else
        {
            GoHome();
        }
    }
    private void GoHome()
    {
        SceneManager.LoadScene("MenuPrincipalScene");
    }
    private void GoHomeWithNoChanges()
    {
        ConfigurationPreferences.ResetConfigurations();
        SceneManager.LoadScene("MenuPrincipalScene");
    }
    private void ResetConfigurations()
    {
        ConfigurationPreferences.ResetConfigurations();
        ConfigurationPreferences.UpdateDarkScreenLayer();
        brightnessSlider.value = ConfigurationPreferences.ScreenBrightness;
        brightnessPercentageLabel.text = ConfigurationPreferences.ScreenBrightness.ToString() + "%";
        existUnsavedChanges = true;
    }
    private void HidePopUpDialog()
    {
        confirmExitContainer.style.display = DisplayStyle.None;
    }
    private void SetNewBrightness(ChangeEvent<float> evt)
    {
        tempBrightnessValue = Mathf.RoundToInt(evt.newValue);
        ConfigurationPreferences.DarkScreenLayer.style.opacity = 0.0085f * (100 - tempBrightnessValue);
        brightnessSlider.value = tempBrightnessValue;
        brightnessPercentageLabel.text = tempBrightnessValue.ToString() + "%";
        existUnsavedChanges = true;
    }
    private void SetNewMusicVolume(ChangeEvent<float> evt)
    {
        tempMusicValue = Mathf.RoundToInt(evt.newValue);
        musicSlider.value = tempMusicValue;
        musicPercentageLabel.text = tempMusicValue.ToString() + "%";
        existUnsavedChanges = true;
    }
    private void SetNewSFXVolume(ChangeEvent<float> evt)
    {
        tempSFXValue = Mathf.RoundToInt(evt.newValue);
        SFXSlider.value = tempSFXValue;
        SFXPercentageLabel.text = tempSFXValue.ToString() + "%";
        existUnsavedChanges = true;
    }
    private void SaveNewConfigurationPreferences()
    {
        print("New configs saved!");
        ConfigurationPreferences.ScreenBrightness = tempBrightnessValue;
        ConfigurationPreferences.MusicVolume = tempMusicValue;
        ConfigurationPreferences.SFXVolume = tempSFXValue;
        existUnsavedChanges = false;
    }
}