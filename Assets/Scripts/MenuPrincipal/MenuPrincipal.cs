using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuPrincipal : MonoBehaviour
{
    private UIDocument UIDocument;
    private VisualElement MenuPrincipall;
    private VisualElement ModosJuego;

    private Button btnInfo;
    private Button btnJugar;
    private Button btnSalir;
    private Button btnInfo2;
    private Button btnHome;
    private Button regresar;


    void OnEnable()
    {
        UIDocument = GetComponent<UIDocument>();
        var root = UIDocument.rootVisualElement;
        
        //obteniendo referencias a UI Elements
        MenuPrincipall = root.Q<VisualElement>("MenuPrincipal");
        ModosJuego = root.Q<VisualElement>("Modos");

        btnInfo = root.Q<Button>("Info");
        btnJugar = root.Q<Button>("Jugar");
        btnSalir = root.Q<Button>("Salir");

        btnInfo2 = root.Q<Button>("Info2");
        btnHome = root.Q<Button>("Home");
        regresar = root.Q<Button>("RegresarMenu");

        btnInfo.RegisterCallback<ClickEvent>(OnInfoClicked);
        btnJugar.RegisterCallback<ClickEvent>(OnModosClicked);
        btnSalir.RegisterCallback<ClickEvent>(OnSalirClicked);
        btnInfo2.RegisterCallback<ClickEvent>(OnInfoClicked);
        btnHome.RegisterCallback<ClickEvent>(OnHomeClicked);
        regresar.RegisterCallback<ClickEvent>(OnHomeClicked);

    }
    private void OnHomeClicked(ClickEvent evt)
    {
        MenuPrincipall.style.display = DisplayStyle.Flex;
        ModosJuego.style.display = DisplayStyle.None;
    }

    private void OnInfoClicked(ClickEvent evt)
    {
        SceneManager.LoadScene("Informacion");
    }
    private void OnModosClicked(ClickEvent evt)
    {
        MenuPrincipall.style.display = DisplayStyle.None;
        ModosJuego.style.display = DisplayStyle.Flex;
    }
    private void OnSalirClicked(ClickEvent evt)
    {
        Application.Quit();
    }
}
