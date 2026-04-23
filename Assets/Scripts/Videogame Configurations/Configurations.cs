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
    private VisualElement root;
    private float tempBrightnessValue;
    private float tempMusicValue;
    private float tempSFXValue;
    private bool existUnsavedChanges = false;
    private VisualElement confirmExitPopUpContainer;
    private VisualElement dialogContainer;
    private Button confirmExitConfigurationWithNoChangesButton;
    private Button discardExitConfigurationButton;
    private Button exitConfigurationCrossButton;
    private Button closePopUpCrossButton;
    
    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

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

        dialogContainer = root.Q<VisualElement>("DialogContainer");

        confirmExitPopUpContainer = root.Q<VisualElement>("ConfirmExitPopUpContainer");
        closePopUpCrossButton = root.Q<Button>("ClosePopUpButton");
        exitConfigurationCrossButton = root.Q<Button>("CloseDialogButton");
        confirmExitConfigurationWithNoChangesButton = root.Q<Button>("ConfirmButton");
        discardExitConfigurationButton = root.Q<Button>("DiscardButton");

        brightnessSlider.value = tempBrightnessValue;
        brightnessPercentageLabel.text = tempBrightnessValue.ToString() + "%";
        musicSlider.value = tempMusicValue;
        musicPercentageLabel.text = tempMusicValue.ToString() + "%";
        SFXSlider.value = tempSFXValue;
        SFXPercentageLabel.text = tempSFXValue.ToString() + "%";

        exitConfigurationCrossButton.clicked += TryGoingHome;
        GetComponent<ConfiguracionBD>().CargarConfiguracion();

        brightnessSlider.RegisterValueChangedCallback(evt => SetNewBrightness(evt));
        musicSlider.RegisterValueChangedCallback(evt => SetNewMusicVolume(evt));
        SFXSlider.RegisterValueChangedCallback(evt => SetNewSFXVolume(evt));
        saveChangesButton.clicked += SaveNewConfigurationPreferences;
        resetConfigurationButton.clicked += ResetConfigurations;

        confirmExitConfigurationWithNoChangesButton.clicked += HidePopUpDialogWithNoChanges;
        discardExitConfigurationButton.clicked += HidePopUpDialog;
        closePopUpCrossButton.clicked += HidePopUpDialog;
    }
    private void TryGoingHome()
    {
        if (existUnsavedChanges)
        {
            AudioManager.Instance.PlayUISFX(AudioClipSet.PopUpDialog);
            confirmExitPopUpContainer.style.display = DisplayStyle.Flex;
        }
        else
        {
            HidePopUpDialogWithNoChanges();
        }
    }
    private void HidePopUpDialogWithNoChanges()
    {
        ConfigurationPreferences.UpdateDarkScreenLayer();
        AudioClipSet.MusicVolume(ConfigurationPreferences.MusicVolume);
        AudioClipSet.SFXVolume(ConfigurationPreferences.SFXVolume);
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickFormerWindow);
        confirmExitPopUpContainer.style.display = DisplayStyle.None;
        dialogContainer.style.display = DisplayStyle.None;
        existUnsavedChanges = false;
        saveChangesButton.SetEnabled(false);
        brightnessSlider.value = ConfigurationPreferences.ScreenBrightness;
        musicSlider.value = ConfigurationPreferences.MusicVolume;
        SFXSlider.value = ConfigurationPreferences.SFXVolume;
    }
    private void HidePopUpDialog()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickDiscard);
        confirmExitPopUpContainer.style.display = DisplayStyle.None;
    }
    private void ResetConfigurations()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickResetChanges);
        ConfigurationPreferences.DarkScreenLayer.style.opacity = 0f;
        AudioClipSet.MusicVolume(60f);
        AudioClipSet.SFXVolume(80f);
        brightnessSlider.value = 100f;
        musicSlider.value = 60f;
        SFXSlider.value = 80f;
        brightnessPercentageLabel.text = "100%";
        musicPercentageLabel.text = "60%";
        SFXPercentageLabel.text = "80%";
        saveChangesButton.SetEnabled(true);
        existUnsavedChanges = true;
    }
    private void SetNewBrightness(ChangeEvent<float> evt)
    {
        tempBrightnessValue = Mathf.RoundToInt(evt.newValue);
        ConfigurationPreferences.DarkScreenLayer.style.opacity = 0.0085f * (100 - tempBrightnessValue);
        brightnessSlider.value = tempBrightnessValue;
        brightnessPercentageLabel.text = tempBrightnessValue.ToString() + "%";
        saveChangesButton.SetEnabled(true);
        existUnsavedChanges = true;
    }
    private void SetNewMusicVolume(ChangeEvent<float> evt)
    {
        tempMusicValue = Mathf.RoundToInt(evt.newValue);
        musicSlider.value = tempMusicValue;
        musicPercentageLabel.text = tempMusicValue.ToString() + "%";
        AudioClipSet.MusicVolume(tempMusicValue);
        saveChangesButton.SetEnabled(true);
        existUnsavedChanges = true;
    }
    private void SetNewSFXVolume(ChangeEvent<float> evt)
    {
        tempSFXValue = Mathf.RoundToInt(evt.newValue);
        SFXSlider.value = tempSFXValue;
        SFXPercentageLabel.text = tempSFXValue.ToString() + "%";
        AudioClipSet.SFXVolume(tempSFXValue);
        saveChangesButton.SetEnabled(true);
        existUnsavedChanges = true;
    }
    private void SaveNewConfigurationPreferences()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickSaveChanges);
        /*ConfigurationPreferences.ScreenBrightness = tempBrightnessValue;
        ConfigurationPreferences.MusicVolume = tempMusicValue;
        ConfigurationPreferences.SFXVolume = tempSFXValue;*/
        SessionData.ScreenBrightness = Mathf.RoundToInt(tempBrightnessValue);
        SessionData.MusicVolumen = Mathf.RoundToInt(tempMusicValue);
        SessionData.SFXVolumen = Mathf.RoundToInt(tempSFXValue);
        GetComponent<ConfiguracionBD>().GuardarConfiguracion();

        saveChangesButton.SetEnabled(false);
        existUnsavedChanges = false;
    }
}