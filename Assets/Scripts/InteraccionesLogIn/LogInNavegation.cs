using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    private UIDocument UIDocument;
    private VisualElement contenedorInicio;
    private VisualElement contenedorRegistro;

    private Label lblRegistro;
    private Label lblIniciarSesion;
    private Button btnMenu;
    private Button btnMenu2;
    void OnEnable()
    {
        UIDocument = GetComponent<UIDocument>();
        var root = UIDocument.rootVisualElement;
        
        //obteniendo referencias a UI Elements
        contenedorInicio = root.Q<VisualElement>("ContenedorInicio");
        contenedorRegistro = root.Q<VisualElement>("ContenedorRegistro");
        lblRegistro = root.Q<Label>("Registro");
        lblIniciarSesion = root.Q<Label>("InicioSesion");
        btnMenu = root.Q<Button>("Ingresar");
        btnMenu2 = root.Q<Button>("Ingresar2");
      



        lblRegistro.RegisterCallback<ClickEvent>(OnRegistroClicked);
        lblIniciarSesion.RegisterCallback<ClickEvent>(OnIniciarSesionClicked);
        btnMenu.RegisterCallback<ClickEvent>(OnMenuClicked);
        btnMenu2.RegisterCallback<ClickEvent>(OnMenuClicked);

    }
  
    private void OnMenuClicked(ClickEvent evt)
    {
        SceneManager.LoadScene("MenuPrincipalScene");
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