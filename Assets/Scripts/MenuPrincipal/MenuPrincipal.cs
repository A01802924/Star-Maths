using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuPrincipal : MonoBehaviour
{
    private UIDocument UIDocument;
    private VisualElement MenuPrincipall;

    private Button btnInfo;
    private Button btnJugar;
    private Button btnSalir;


    void OnEnable()
    {
        UIDocument = GetComponent<UIDocument>();
        var root = UIDocument.rootVisualElement;
        
        //obteniendo referencias a UI Elements
        MenuPrincipall = root.Q<VisualElement>("MenuPrincipal");

        btnInfo = root.Q<Button>("Info");
        btnJugar = root.Q<Button>("Jugar");
        btnSalir = root.Q<Button>("Salir");

        btnInfo.RegisterCallback<ClickEvent>(OnInfoClicked);
        btnJugar.RegisterCallback<ClickEvent>(OnModosClicked);
        btnSalir.RegisterCallback<ClickEvent>(OnSalirClicked);
  
    }
    private void OnInfoClicked(ClickEvent evt)
    {
        SceneManager.LoadScene("Informacion");
    }
    private void OnModosClicked(ClickEvent evt)
    {
        SceneManager.LoadScene("ModosJuegoScene");
    }
    private void OnSalirClicked(ClickEvent evt)
    {
        Application.Quit();
    }
}
