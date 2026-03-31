using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private UIDocument UIDocument;
    private VisualElement contenedorInicio;
    private VisualElement contenedorRegistro;
    private VisualElement MenuPrincipal;
    private Label lblRegistro;
    private Label lblIniciarSesion;
    private Button btnMenu;

    void OnEnable()
    {
        UIDocument = GetComponent<UIDocument>();
        var root = UIDocument.rootVisualElement;
        
        //obteniendo referencias a UI Elements
        contenedorInicio = root.Q<VisualElement>("ContenedorInicio");
        contenedorRegistro = root.Q<VisualElement>("ContenedorRegistro");
        MenuPrincipal = root.Q<VisualElement>("MenuPrincipal");
        lblRegistro = root.Q<Label>("Registro");
        lblIniciarSesion = root.Q<Label>("InicioSesion");
        btnMenu = root.Q<Button>("Ingresar");


        lblRegistro.RegisterCallback<ClickEvent>(OnRegistroClicked);
        lblIniciarSesion.RegisterCallback<ClickEvent>(OnIniciarSesionClicked);
        btnMenu.RegisterCallback<ClickEvent>(OnMenuClicked);

    }

    private void OnMenuClicked(ClickEvent evt)
    {
        contenedorInicio.style.display = DisplayStyle.None;
        contenedorRegistro.style.display = DisplayStyle.None;
        MenuPrincipal.style.display = DisplayStyle.Flex;
        
        Debug.Log("Cambiando a pantalla de Menú Principal");
    }

    private void OnIniciarSesionClicked(ClickEvent evt)
    {
        contenedorRegistro.style.display = DisplayStyle.None;
        contenedorInicio.style.display = DisplayStyle.Flex;
        
        Debug.Log("Cambiando a pantalla de Inicio de Sesión");
    }

    private void OnRegistroClicked(ClickEvent evt)
    {
        contenedorInicio.style.display = DisplayStyle.None;
        contenedorRegistro.style.display = DisplayStyle.Flex;
        
        Debug.Log("Cambiando a pantalla de Registro");
    }

    void OnDisable()
    {
        if (lblRegistro != null)
            lblRegistro.UnregisterCallback<ClickEvent>(OnRegistroClicked);
    }
}