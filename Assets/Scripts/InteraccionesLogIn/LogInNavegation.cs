using UnityEngine;
using UnityEngine.UIElements;
using Assets.Scripts.Core;


public class MenuManager : MonoBehaviour
{
    private UIDocument UIDocument;
    private VisualElement contenedorInicio;
    private VisualElement contenedorRegistro;

    private Label lblRegistro;
    private Label lblIniciarSesion;

    void OnEnable()
    {
        UIDocument = GetComponent<UIDocument>();
        VisualElement root = UIDocument.rootVisualElement;

        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();

        contenedorInicio = root.Q<VisualElement>("ContenedorInicio");
        contenedorRegistro = root.Q<VisualElement>("ContenedorRegistro");
        lblRegistro = root.Q<Label>("Registro");
        lblIniciarSesion = root.Q<Label>("InicioSesion");

        lblRegistro.RegisterCallback<ClickEvent>(OnRegistroClicked);
        lblIniciarSesion.RegisterCallback<ClickEvent>(OnIniciarSesionClicked);
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