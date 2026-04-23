using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Info : MonoBehaviour
{
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();

        Button puntajes = root.Q<Button>("RankingButton");

        Button tienda = root.Q<Button>("StoreButton");

        Button tutoral = root.Q<Button>("TutorialButton");

        Button home = root.Q<Button>("home");

        puntajes.RegisterCallback<ClickEvent>(AbrirPuntajes);
        void AbrirPuntajes(ClickEvent evt)
        {
            AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
            SceneManager.LoadScene("Puntuacion");
        }

        tienda.RegisterCallback<ClickEvent>(AbrirTienda);
        void AbrirTienda(ClickEvent evt)
        {
            AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
            SceneManager.LoadScene("Store");
        }

        tutoral.RegisterCallback<ClickEvent>(AbrirTutorial);
        void AbrirTutorial(ClickEvent evt)
        {
            AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
            SceneManager.LoadScene("Tutorial");
        }

        home.RegisterCallback<ClickEvent>(AbrirHome);
        void AbrirHome(ClickEvent evt)
        {
            AudioManager.Instance.PlayUISFX(AudioClipSet.ClickFormerWindow);
            SceneManager.LoadScene("MenuPrincipalScene");
        }
    }
}

