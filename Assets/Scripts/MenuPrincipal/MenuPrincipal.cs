using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEditor;
using Assets.Scripts.Core;

public class MenuPrincipal : MonoBehaviour
{
    private UIDocument UIDocument;
    private VisualElement MenuPrincipall;
    private VisualElement Creditos;

    private Button btnInfo;
    private Button btnJugar;
    private Button btnSalir;
    private Button btnCreditos;
    private Button btnRegresarMenu;
    private Button btnConfig;


    void OnEnable()
    {
        UIDocument = GetComponent<UIDocument>();
        var root = UIDocument.rootVisualElement;

        ConfigurationPreferences.UpdateDarkScreenLayer();
        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();

        //obteniendo referencias a UI Elements
        MenuPrincipall = root.Q<VisualElement>("MenuPrincipal");
        Creditos = root.Q<VisualElement>("Creditos");

        btnInfo = root.Q<Button>("Info");
        btnJugar = root.Q<Button>("Jugar");
        btnSalir = root.Q<Button>("Salir");
        btnCreditos = root.Q<Button>("btnCreditos");
        btnRegresarMenu = root.Q<Button>("RegresarBoton");
        btnConfig = root.Q<Button>("Config");

        btnInfo.RegisterCallback<ClickEvent>(OnInfoClicked);
        btnJugar.RegisterCallback<ClickEvent>(OnModosClicked);
        btnSalir.RegisterCallback<ClickEvent>(OnSalirClicked);
        btnCreditos.RegisterCallback<ClickEvent>(OnCreditosClicked);
        btnRegresarMenu.RegisterCallback<ClickEvent>(OnRegresarMenuClicked);
        btnConfig.RegisterCallback<ClickEvent>(OnConfigClicked);
    }
    private void OnConfigClicked(ClickEvent evt)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
        SceneManager.LoadScene("Configuration");
    }
    private void OnRegresarMenuClicked(ClickEvent evt)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickFormerWindow);
        Creditos.style.display = DisplayStyle.None;
        MenuPrincipall.style.display = DisplayStyle.Flex;
    }
    private void OnCreditosClicked(ClickEvent evt)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
        MenuPrincipall.style.display = DisplayStyle.None;
        Creditos.style.display = DisplayStyle.Flex;
    }
    private void OnInfoClicked(ClickEvent evt)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
        SceneManager.LoadScene("Informacion");
    }
    private void OnModosClicked(ClickEvent evt)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
        SceneManager.LoadScene("ModosJuegoScene");
    }
    private void OnSalirClicked(ClickEvent evt)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickFormerWindow);
        Debug.Log("Saliendo del juego..."); // Para que verifiques en consola que sí detecta el clic
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif    
    }
}
