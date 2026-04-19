using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ControlesNiveles : MonoBehaviour
{
    private Button nivel1;
    private Button nivel2;
    private Button nivel3;
    private Button nivel4;
    private Button info;
    private Button home;
    private Button regresar;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();

        nivel1 = root.Q<Button>("1");
        nivel2 = root.Q<Button>("2");
        nivel3 = root.Q<Button>("3");
        nivel4 = root.Q<Button>("4");

        info = root.Q<Button>("info");
        regresar = root.Q<Button>("regresar");
        home = root.Q<Button>("home");

        nivel1.clicked += () => MostrarGameplay(1);
        nivel2.clicked += () => MostrarGameplay(2);
        nivel3.clicked += () => MostrarGameplay(3);
        nivel4.clicked += () => MostrarGameplay(4);

        nivel1.RegisterCallback<MouseEnterEvent>(HoverLevel);
        nivel2.RegisterCallback<MouseEnterEvent>(HoverLevel);
        nivel3.RegisterCallback<MouseEnterEvent>(HoverLevel);
        nivel4.RegisterCallback<MouseEnterEvent>(HoverLevel);

        info.clicked += MostrarInfo;
        regresar.clicked += Regresar;
        home.clicked += VolverMenuPrincipal;
    }
    private void HoverLevel(MouseEnterEvent evt)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.HoverLevel);
    }
    private void MostrarGameplay(int levelIndex)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
        AudioManager.Instance.PlayNewTrack(AudioClipSet.LevelGameBackgroundMusic);
        SessionData.SelectedLevelID = levelIndex;
        SceneManager.LoadScene("JuegoMeteoritos");
    }
    private void MostrarInfo()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
        SceneManager.LoadScene("Informacion");
    }
    private void Regresar()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickFormerWindow);
        SceneManager.LoadScene("Mundos");
    }
    private void VolverMenuPrincipal()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickFormerWindow);
        SceneManager.LoadScene("MenuPrincipalScene");
    }
}
