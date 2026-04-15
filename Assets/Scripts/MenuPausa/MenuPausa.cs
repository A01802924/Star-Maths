using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuPausa : MonoBehaviour
{
    public static MenuPausa instance;

    private VisualElement menuPausa;
    private VisualElement HUD;
    private VisualElement vida1;
    private VisualElement vida2;
    private VisualElement vida3;

    private Button resume;
    private Button restart;
    private Button options;
    private Button mainMenu;
    private Button pausar;

    private Label operacion;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        menuPausa = root.Q<VisualElement>("MenuPausa");
        HUD = root.Q<VisualElement>("PlayerHUD");
        vida1 = root.Q<VisualElement>("Vida1");
        vida2 = root.Q<VisualElement>("Vida2");
        vida3 = root.Q<VisualElement>("Vida3");

        resume = root.Q<Button>("Reanudar");
        restart = root.Q<Button>("Reiniciar");
        options = root.Q<Button>("Opciones");
        mainMenu = root.Q<Button>("MenuPrincipal");
        pausar = root.Q<Button>("BotonPausa");

        operacion = root.Q<Label>("Operacion");

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
        pausar.style.display = DisplayStyle.None;
        Time.timeScale = 0f;
    }

    public void OcultarMenu()
    {
        menuPausa.style.display = DisplayStyle.None;
        HUD.style.display = DisplayStyle.Flex;
        pausar.style.display = DisplayStyle.Flex;
        Time.timeScale = 1f;
    }

    private void Continuar()
    {
        OcultarMenu();
    }

    private void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void MenuOpciones()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Configuration");
    }

    private void VolverMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipalScene");
    }

    private void Pausar()
    {
        MostrarMenu();
    }

    public void ActualizarVidas()
    {
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
}