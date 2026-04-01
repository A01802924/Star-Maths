using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuPausa : MonoBehaviour
{
    private VisualElement menuPausa;
    private Button resume;
    private Button restart;
    private Button options;
    private Button mainMenu;
    private Button pausar;


    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        menuPausa = root.Q<VisualElement>("MenuPausa");

        resume = root.Q<Button>("Reanudar");
        restart = root.Q<Button>("Reiniciar");
        options = root.Q<Button>("Opciones");
        mainMenu = root.Q<Button>("MenuPrincipal");

        pausar = root.Q<Button>("BotonPausa");

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
        pausar.style.display = DisplayStyle.None;
        Time.timeScale = 0f;
    }

    public void OcultarMenu()
    {
        menuPausa.style.display = DisplayStyle.None;
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
        print("Menú opciones abierto");
    }

    private void VolverMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void Pausar()
    {
        MostrarMenu();
    }
}
