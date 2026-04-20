using System.Collections.Generic;
using Assets.Scripts.Core;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Configurations : MonoBehaviour
{
    // public Configurations instance;
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

    private VisualElement modalContainer;
    private Button regresar;

    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();

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

        modalContainer = root.Q<VisualElement>("ModalContainer");
        regresar = root.Q<Button>("Cerrar");

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
        confirmExitConfigurationButton.clicked += GoHome;
        discardExitConfigurationButton.clicked += HidePopUpDialog;

        regresar.clicked += CerrarMenu;
    }
    private void TryGoingHome()
    {
        if (existUnsavedChanges)
        {
            AudioManager.Instance.PlayUISFX(AudioClipSet.PopUpDialog);
            confirmExitContainer.style.display = DisplayStyle.Flex;
        }
        else
        {
            GoHome();
        }
    }
    private void GoHome()
    {
        AudioClipSet.MusicVolume(ConfigurationPreferences.MusicVolume);
        AudioClipSet.SFXVolume(ConfigurationPreferences.SFXVolume);
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickFormerWindow);
        SceneManager.LoadScene("MenuPrincipalScene");
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
    private void HidePopUpDialog()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickDiscard);
        confirmExitContainer.style.display = DisplayStyle.None;
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
        ConfigurationPreferences.ScreenBrightness = tempBrightnessValue;
        ConfigurationPreferences.MusicVolume = tempMusicValue;
        ConfigurationPreferences.SFXVolume = tempSFXValue;
        saveChangesButton.SetEnabled(false);
        existUnsavedChanges = false;
    }

    public void CerrarMenu()
    {
        modalContainer.style.display = DisplayStyle.None;
        MenuPausa.instance.MostrarMenu();
    }

    public void MostrarMenu()
    {
        modalContainer.style.display = DisplayStyle.Flex;
    }

    public void MostrarMenuInPrincipal()
    {
        modalContainer.style.display = DisplayStyle.Flex;
        regresar.style.display = DisplayStyle.None;
    }
}