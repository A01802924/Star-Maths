using Assets.Scripts.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuPausa : MonoBehaviour
{
    public static MenuPausa instance;
    private Configurations config;

    private VisualElement menuPausa;
    public VisualElement HUD;
    public VisualElement infoHUD;
    private VisualElement vida1;
    private VisualElement vida2;
    private VisualElement vida3;
    public VisualElement respuestas;

    private Button resume;
    private Button restart;
    private Button options;
    private Button mainMenu;
    private Button pausar;

    private Label correctas;

    private LevelGame game;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if(config == null)
        {
            config = FindAnyObjectByType<Configurations>();
        }
    }

    void Start()
    {
        game = new LevelGame(LevelFactory.BuildLevel(SessionData.SelectedWorldID, SessionData.SelectedLevelID));

        var root = GetComponent<UIDocument>().rootVisualElement;

        root.Add(ConfigurationPreferences.DarkScreenLayer);

        menuPausa = root.Q<VisualElement>("MenuPausa");
        HUD = root.Q<VisualElement>("PlayerHUD");
        vida1 = root.Q<VisualElement>("Vida1");
        vida2 = root.Q<VisualElement>("Vida2");
        vida3 = root.Q<VisualElement>("Vida3");
        respuestas = root.Q<VisualElement>("Respuestas");
        infoHUD = root.Q<VisualElement>("InfoHUD");

        resume = root.Q<Button>("Reanudar");
        restart = root.Q<Button>("Reiniciar");
        options = root.Q<Button>("Opciones");
        mainMenu = root.Q<Button>("MenuPrincipal");
        pausar = root.Q<Button>("BotonPausa");

        correctas = root.Q<Label>("Contador");

        menuPausa.style.display = DisplayStyle.None;

        resume.clicked += Continuar;
        restart.clicked += ReiniciarNivel;
        options.clicked += MenuOpciones;
        mainMenu.clicked += VolverMenuPrincipal;
        pausar.clicked += Pausar;
    }

    public void MostrarMenu()
    {
        menuPausa.style.display = DisplayStyle.Flex;
        HUD.style.display = DisplayStyle.None;
        infoHUD.style.display = DisplayStyle.None;
        pausar.style.display = DisplayStyle.None;
        Time.timeScale = 0f;
    }

    public void OcultarMenu()
    {
        menuPausa.style.display = DisplayStyle.None;
        infoHUD.style.display = DisplayStyle.Flex;
        HUD.style.display = DisplayStyle.Flex;
        pausar.style.display = DisplayStyle.Flex;
        Time.timeScale = 1f;
    }

    private void Continuar()
    {
        // TODO: If game is resumed, resume game background music source but from the latest played second of the file before pause mode
        if (SessionData.JuegoJefe)
        {
            AudioManager.Instance.PlayNewTrack(AudioClipSet.BossGameBackgroundMusic);
        }
        else
        {
            AudioManager.Instance.PlayNewTrack(AudioClipSet.LevelGameBackgroundMusic);
        }
        OcultarMenu();

        game.startCronometer();
    }

    private void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        if (SessionData.JuegoJefe)
        {
            AudioManager.Instance.PlayNewTrack(AudioClipSet.BossGameBackgroundMusic);
        }
        else
        {
            AudioManager.Instance.PlayNewTrack(AudioClipSet.LevelGameBackgroundMusic);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void MenuOpciones()
    {
        AudioManager.Instance.PlayNewTrack(AudioClipSet.MainBackgroundMusic);
        config.MostrarMenu();
        OcultarMenu();
        HUD.style.display = DisplayStyle.None;
        infoHUD.style.display = DisplayStyle.None;
        Time.timeScale = 0f;
    }

    private void VolverMenuPrincipal()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlayNewTrack(AudioClipSet.MainBackgroundMusic);
        SceneManager.LoadScene("MenuPrincipalScene");
    }

    private void Pausar()
    {
        AudioManager.Instance.PlayNewTrack(AudioClipSet.PauseBackgroundMusic);
        MostrarMenu();

        game.stopCronometer();
    }

    public void ActualizarVidas()
    {
        vidaNave.instance.vidas--;
        int vidas = vidaNave.instance.vidas;

        if ( vidas == 0 )
        {
            vida1.style.display = DisplayStyle.None;
            vidaNave.instance.Perder();
        } else if ( vidas == 1 )
        {
            vida2.style.display = DisplayStyle.None;
        } else if ( vidas == 2 )
        {
            vida3.style.display = DisplayStyle.None;
        }
    }

    public void ActualizarCorrectas(int x)
    {
        vidaNave.instance.correctas++;
        string count = vidaNave.instance.correctas.ToString();

        correctas.text = $"{count}/{x}";

        if (vidaNave.instance.correctas >= x)
        {
            vidaNave.instance.Ganar(x);
        }
    }
}