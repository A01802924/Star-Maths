using UnityEngine;
using UnityEngine.UIElements; // Necesario para UI Toolkit
using UnityEngine.SceneManagement;
using Assets.Scripts.Core;

public class ControladorUI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();

        Button botonCambio = root.Q<Button>("Inicio");

        if (botonCambio != null)
        {
            botonCambio.clicked += OnBotonClicked;
        }
    }

    private void OnBotonClicked()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
        SceneManager.LoadScene("LoginScene");
    }
}